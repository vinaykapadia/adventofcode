using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Common;

public static class Utilities
{
    public static object PartBAnswer { get; set; }

    public static string CalculateMd5Hash(string input)
    {
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hash = MD5.HashData(inputBytes);
        var sb = new StringBuilder();
        foreach (var t in hash)
        {
            sb.Append(t.ToString("X2"));
        }

        return sb.ToString();
    }

    public static void Progress(long current, long total)
    {
        Progress((int)(current * 100 / total));
    }

    public static void Progress(int percent)
    {
        Console.CursorLeft = 0;
        Console.Write("|");
        for (var i = 0; i < percent; i++)
        {
            Console.Write("\u2588");
        }
        for (var i = percent; i < 100; i++)
        {
            Console.Write("_");
        }
        Console.Write("|");
    }
}