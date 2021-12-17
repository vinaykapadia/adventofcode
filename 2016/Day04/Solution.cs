using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2016.Day04;

[ProblemName("Security Through Obscurity")]      
internal class Solution : Solver
{
    Dictionary<string, int> validRooms = new Dictionary<string, int>();

    public object PartOne(string input)
    {
        Regex lettersReg = new Regex("[a-z]+");
        Regex numbersReg = new Regex(@"\d+");

        foreach (var line in input.Replace("-", "").Lines())
        {
            MatchCollection matches = lettersReg.Matches(line);
            Match numMatch = numbersReg.Match(line);
            string name = matches[0].ToString();
            string checksum = matches[1].ToString();
            int sector = int.Parse(numMatch.ToString());
            if (IsValid(name, checksum))
            {
                validRooms.Add(name, sector);
            }
        }

        return validRooms.Sum(x => x.Value);
    }

    public object PartTwo(string input)
    {
        Dictionary<string, int> unencryptedRooms = new Dictionary<string, int>();
        foreach (var room in validRooms)
        {
            string name = "";
            foreach (var letter in room.Key)
            {
                name += (char)((letter - 'a' + 26 + room.Value) % 26 + 'a');
            }

            unencryptedRooms.Add(name, room.Value);
        }

        return unencryptedRooms.First(x => x.Key.StartsWith("northpole")).Value;
    }

    private static bool IsValid(string name, string checksum)
    {
        Dictionary<char, int> maps = new Dictionary<char, int>();
        foreach (var letter in name)
        {
            if (!maps.ContainsKey(letter)) maps.Add(letter, 0);
            maps[letter]++;
        }

        string check = new string(maps.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(5).Select(x => x.Key).ToArray());
        return check == checksum;
    }
}
