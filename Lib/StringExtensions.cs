using System.Text.RegularExpressions;

namespace AdventOfCode;

public static class StringExtensions {
    public static string StripMargin(this string st, string margin = "|") {
        return string.Join("\n",
            from line in Regex.Split(st, "\r?\n")
            select Regex.Replace(line, @"^\s*"+Regex.Escape(margin), "")
        );
    }

    public static string Indent(this string st, int l, bool firstLine = false) {
        var indent = new string(' ', l);
        var res = string.Join("\n" + new string(' ', l),
            from line in Regex.Split(st, "\r?\n")
            select Regex.Replace(line, @"^\s*\|", "")
        );
        return firstLine ? indent + res : res;
    }

    public static ColoredString WithColor(this string st, ConsoleColor c)
    {
	    return new ColoredString(c, st);
    }

    public static string[] Lines(this string st) => st.Split('\n');

    public static IList<int> Nums(this string st) => st.Split(',').Select(int.Parse).ToList();
}

public record ColoredString(ConsoleColor c, string st);
