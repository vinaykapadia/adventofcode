using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Common;

public static class Utilities
{
    public static object PartBAnswer { get; set; }

    public static string CalculateMd5Hash(string input)
    {
        var md5 = MD5.Create();
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hash = md5.ComputeHash(inputBytes);
        var sb = new StringBuilder();
        foreach (var t in hash)
        {
            sb.Append(t.ToString("X2"));
        }

        return sb.ToString();
    }
}