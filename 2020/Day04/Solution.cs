namespace AdventOfCode._2020.Day04;

[ProblemName("Passport Processing")]      
internal class Solution : ISolver
{
    private class Passport
    {
        public string Byr { get; set; }
        public string Iyr { get; set; }
        public string Eyr { get; set; }
        public string Hgt { get; set; }
        public string Hcl { get; set; }
        public string Ecl { get; set; }
        public string Pid { get; set; }
        public string Cid { get; set; }
    }


    List<Passport> passports = new();

    public object PartOne(string input)
    {
        var current = new Passport();
        
        foreach (var line in input.Lines())
        {
            if (line == "")
            {
                passports.Add(current);
                current = new Passport();
                continue;
            }

            foreach (var prop in line.Split(' '))
            {
                string value = prop[4..];
                switch (prop[..3])
                {
                    case "byr":
                        current.Byr = value;
                        break;
                    case "iyr":
                        current.Iyr = value;
                        break;
                    case "eyr":
                        current.Eyr = value;
                        break;
                    case "hgt":
                        current.Hgt = value;
                        break;
                    case "hcl":
                        current.Hcl = value;
                        break;
                    case "ecl":
                        current.Ecl = value;
                        break;
                    case "pid":
                        current.Pid = value;
                        break;
                    case "cid":
                        current.Cid = value;
                        break;
                }
            }
        }
        passports.Add(current);

        return passports.Count(passport =>
            !string.IsNullOrEmpty(passport.Byr)
            && !string.IsNullOrEmpty(passport.Eyr)
            && !string.IsNullOrEmpty(passport.Iyr)
            && !string.IsNullOrEmpty(passport.Hgt)
            && !string.IsNullOrEmpty(passport.Hcl)
            && !string.IsNullOrEmpty(passport.Ecl)
            && !string.IsNullOrEmpty(passport.Pid));
    }

    public object PartTwo(string input)
    {
        return passports.Count(Validate);
    }

    private static readonly string[] EyeColors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
    private static bool Validate(Passport p)
    {
        if (string.IsNullOrEmpty(p.Byr)
            || string.IsNullOrEmpty(p.Eyr)
            || string.IsNullOrEmpty(p.Iyr)
            || string.IsNullOrEmpty(p.Hgt)
            || string.IsNullOrEmpty(p.Hcl)
            || string.IsNullOrEmpty(p.Ecl)
            || string.IsNullOrEmpty(p.Pid))
            return false;

        try
        {
            int x = int.Parse(p.Byr);
            if (x is < 1920 or > 2002) return false;

            x = int.Parse(p.Iyr);
            if (x is < 2010 or > 2020) return false;

            x = int.Parse(p.Eyr);
            if (x is < 2020 or > 2030) return false;

            if (!ValidHeight(p.Hgt)) return false;

            if (p.Hcl.Length != 7) return false;
            if (p.Hcl[0] != '#') return false;
            for (int i = 1; i < 7; i++)
            {
                if ((p.Hcl[i] < '0' || p.Hcl[i] > '9') && (p.Hcl[i] < 'a' || p.Hcl[i] > 'f')) return false;
            }

            if (!EyeColors.Contains(p.Ecl)) return false;

            if (p.Pid.Length != 9) return false;
            for (int i = 0; i < 9; i++)
            {
                if (p.Pid[i] < '0' || p.Pid[i] > '9') return false;
            }

            return true;
        }
        catch
        {
            return false;
        }
    }

    private static bool ValidHeight(string h)
    {
        string unit = h[^2..];
        int value = int.Parse(h[..^2]);
        switch (unit)
        {
            case "cm" when value is >= 150 and <= 193:
            case "in" when value is >= 59 and <= 76:
                return true;
            default:
                return false;
        }
    }
}
