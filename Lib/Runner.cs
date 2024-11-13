using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AdventOfCode.Lib;

internal class ProblemNameAttribute(string name) : Attribute
{
    public readonly string Name = name;
}

internal interface ISolver {
    object PartOne(string input);
    object PartTwo(string input) => null;
}

internal static class SolverExtensions {

    public static IEnumerable<object> Solve(this ISolver solver, string input) {
        yield return solver.PartOne(input);
        var res = solver.PartTwo(input);
        if (res != null) {
            yield return res;
        }
    }

    public static string GetName(this ISolver solver) {
        return (
            solver
                .GetType()
                .GetCustomAttribute(typeof(ProblemNameAttribute)) as ProblemNameAttribute ?? new ProblemNameAttribute("")
        ).Name;
    }

    public static string DayName(this ISolver solver) {
        return $"Day {solver.Day()}";
    }

    public static int Year(this ISolver solver) {
        return Year(solver.GetType());
    }

    public static int Year(Type t) {
        return int.Parse((t.FullName?.Split('.')[1])?[1..] ?? "0");
    }
    public static int Day(this ISolver solver) {
        return Day(solver.GetType());
    }

    public static int Day(Type t) {
        return int.Parse((t.FullName?.Split('.')[2])?[3..] ?? "0");
    }

    public static string WorkingDir(int year) {
        return Path.Combine(year.ToString());
    }

    public static string WorkingDir(int year, int day) {
        return Path.Combine(WorkingDir(year), "Day" + day.ToString("00"));
    }

    public static string WorkingDir(this ISolver solver) {
        return WorkingDir(solver.Year(), solver.Day());
    }

    public static ISplashScreen SplashScreen(this ISolver solver) {
        var tSplashScreen = Assembly.GetEntryAssembly()?.GetTypes()
             .Where(t => t.GetTypeInfo().IsClass && typeof(ISplashScreen).IsAssignableFrom(t))
             .Single(t => Year(t) == solver.Year());
        return (ISplashScreen)Activator.CreateInstance(tSplashScreen ?? Assembly.GetCallingAssembly().GetTypes()[0]);
    }

    public static int Sloc(this ISolver solver)
    {
	    var file = solver.WorkingDir() + "/Solution.cs";
	    if (File.Exists(file))
	    {
		    var solution = File.ReadAllText(file);
		    return Regex.Matches(solution, @"\n").Count;
	    }
	    return -1;
    }
}

internal record SolverResult(string[] Answers, string[] Errors);

internal class Runner {

    private static string GetNormalizedInput(string file) {
        var input = File.ReadAllText(file);
        if (input.EndsWith('\n')) {
            input = input[..^1];
        }
        return input;
    }

    public static SolverResult RunSolver(ISolver solver) {

        var workingDir = solver.WorkingDir();
        const string indent = "    ";
        Write(ConsoleColor.White, $"{indent}{solver.DayName()}: {solver.GetName()}");
        WriteLine();
        var file = Path.Combine(workingDir, "input.in");
        var refoutFile = file.Replace(".in", ".refout");
        var refout = File.Exists(refoutFile) ? File.ReadAllLines(refoutFile) : null;
        var input = GetNormalizedInput(file);
        var iLine = 0;
        var answers = new List<string>();
        var errors = new List<string>();
        var stopwatch = Stopwatch.StartNew();
        foreach (var line in solver.Solve(input)) {
            var ticks = stopwatch.ElapsedTicks;
            if (line is OcrString ocrString) {
                Console.WriteLine("\n" + ocrString.st.Indent(10, true));
            }
            answers.Add(line.ToString());
            var (statusColor, status, err) =
                refout == null || refout.Length <= iLine ? (ConsoleColor.Cyan, "?", null) :
                refout[iLine] == line.ToString() ? (ConsoleColor.DarkGreen, "✓", null) :
                (ConsoleColor.Red, "X", $"{solver.DayName()}: In line {iLine + 1} expected '{refout[iLine]}' but found '{line}'");

            if (err != null) {
                errors.Add(err);
            }

            Write(statusColor, $"{indent}  {status}");
            Console.Write($" {line} ");
            var diff = ticks * 1000.0 / Stopwatch.Frequency;

            WriteLine(
                diff > 1000 ? ConsoleColor.Red :
                diff > 500 ? ConsoleColor.Yellow :
                ConsoleColor.DarkGreen,
                $"({diff:F3} ms)"
            );
            iLine++;
            stopwatch.Restart();
        }

        return new SolverResult([.. answers], [.. errors]);
    }

    public static void RunAll(params ISolver[] solvers) {
        var errors = new List<string>();

        var lastYear = -1;
        List<(int day, int sloc)> slocs = new();
        foreach (var solver in solvers) {
            if (lastYear != solver.Year())
            {
	            SlocChart.Show(slocs);
	            slocs.Clear();

				solver.SplashScreen().Show();
                lastYear = solver.Year();
            }

            slocs.Add((solver.Day(), solver.Sloc()));
			var result = RunSolver(solver);
            WriteLine();
            errors.AddRange(result.Errors);
        }

        SlocChart.Show(slocs);
		WriteLine();

        if (errors.Any()) {
            WriteLine(ConsoleColor.Red, "Errors:\n" + string.Join("\n", errors));
        }
    }

    private static void WriteLine(ConsoleColor color = ConsoleColor.Gray, string text = "") {
        Write(color, text + "\n");
    }
    private static void Write(ConsoleColor color = ConsoleColor.Gray, string text = "") {
        var c = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = c;
    }
}
