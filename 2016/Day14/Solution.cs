using System.Collections.Generic;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode._2016.Day14;

[ProblemName("One-Time Pad")]      
internal class Solution : ISolver
{

    public object PartOne(string input)
    {
        int keys = 0;
        int index = 0;

        IList<string> hashes = new List<string>();

        for (int i = 0; i < 40000; i++)
        {
            string h = input + i;
            h = Utilities.CalculateMd5Hash(h);

            hashes.Add(h);
        }

        while (keys < 64)
        {
            string hash;
            if (hashes.Count > index)
            {
                hash = hashes[index];
            }
            else
            {
                hash = Utilities.CalculateMd5Hash(input + index);
                hashes.Add(hash);
            }

            if (HasThree(hash, out char c))
            {
                for (int i = 1; i <= 1000; i++)
                {
                    string checkHash;
                    if (hashes.Count > index + i)
                    {
                        checkHash = hashes[i + index];
                    }
                    else
                    {
                        checkHash = Utilities.CalculateMd5Hash(input + (index + i));
                        hashes.Add(checkHash);
                    }

                    if (HasFive(checkHash, c))
                    {
                        keys++;
                        i = 1001;
                    }
                }
            }

            index++;
        }

        index--;
        return index;
    }

    public object PartTwo(string input)
    {
        int keys = 0;
        int index = 0;

        IList<string> hashes = new List<string>();

        for (int i = 0; i < 40000; i++)
        {
            string h = input + i;
            h = Utilities.CalculateMd5Hash(h);
            for (int a = 0; a < 2016; a++)
            {
                h = Utilities.CalculateMd5Hash(h);
            }

            hashes.Add(h);
        }

        while (keys < 64)
        {
            string hash;
            if (hashes.Count > index)
            {
                hash = hashes[index];
            }
            else
            {
                hash = input + index;
                hash = Utilities.CalculateMd5Hash(hash);
                for (int h = 0; h < 2016; h++)
                {
                    hash = Utilities.CalculateMd5Hash(hash);
                }

                hashes.Add(hash);
            }

            if (HasThree(hash, out char c))
            {
                for (int i = 1; i <= 1000; i++)
                {
                    string checkHash;
                    if (hashes.Count > index + i)
                    {
                        checkHash = hashes[i + index];
                    }
                    else
                    {
                        checkHash = Utilities.CalculateMd5Hash(input + (index + i));

                        for (int h = 0; h < 2016; h++)
                        {
                            checkHash = Utilities.CalculateMd5Hash(hash);
                        }

                        hashes.Add(checkHash);
                    }

                    if (HasFive(checkHash, c))
                    {
                        keys++;
                        i = 1001;
                    }
                }
            }

            index++;
        }

        index--;
        return index;
    }

    private static bool HasThree(string text, out char c)
    {
        for (var i = 0; i < text.Length - 2; i++)
        {
            if (text[i] == text[i + 1] && text[i] == text[i + 2])
            {
                c = text[i];
                return true;
            }
        }

        c = '\0';
        return false;
    }

    private static bool HasFive(string text, char c)
    {
        return Regex.IsMatch(text, $"[{c}]{{5}}");
    }
}
