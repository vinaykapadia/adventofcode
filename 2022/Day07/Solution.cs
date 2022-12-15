namespace AdventOfCode._2022.Day07;

[ProblemName("No Space Left On Device")]      
internal class Solution : ISolver
{
    private readonly Directory _home = new()
    {
        Name = "/",
        Parent = null
    };

    public object PartOne(string input)
    {
        var current = _home;

        var i = 0;
        var lines = input.Lines();

        while (i < lines.Length)
        {
            if (lines[i][..4] == "$ cd")
            {
                if (lines[i][5] == '/')
                {
                    current = _home;
                }
                else if (lines[i][5..7] == "..")
                {
                    current = current.Parent;
                }
                else
                {
                    current = (Directory)current.Contents.First(x => x.Name == lines[i][5..]);
                }

                i++;
            }
            else
            {
                i++;
                while (i < lines.Length && lines[i][0] != '$')
                {
                    var split = lines[i].Split(' ');
                    var size = split[0];
                    var name = split[1];
                    if (current.Contents.Any(x => x.Name == name))
                    {
                        continue;
                    }

                    IElement newElement;
                    if (size == "dir")
                    {
                        newElement = new Directory();
                    }
                    else
                    {
                        newElement = new File
                        {
                            Size = int.Parse(size)
                        };
                    }

                    newElement.Name = name;
                    newElement.Parent = current;
                    current.Contents.Add(newElement);

                    i++;
                }
            }
        }

        var smallDirs = new List<int>();
        GetSmallDirs(_home, smallDirs);

        return smallDirs.Sum(x => x);
    }

    public object PartTwo(string input)
    {
        var spaceNeeded = 30000000 - 70000000 + _home.GetSize();

        var largeDirs = new List<int>();
        GetLargeDirs(_home, largeDirs, spaceNeeded);

        return largeDirs.Min(x => x);
    }

    private static void GetSmallDirs(Directory dir, ICollection<int> smallDirs)
    {
        if (dir.GetSize() < 100000)
        {
            smallDirs.Add(dir.GetSize());
        }

        foreach (var element in dir.Contents)
        {
            if (element is Directory subDir)
            {
                GetSmallDirs(subDir, smallDirs);
            }
        }
    }

    private static void GetLargeDirs(Directory dir, ICollection<int> largeDirs, int size)
    {
        if (dir.GetSize() > size)
        {
            largeDirs.Add(dir.GetSize());
        }

        foreach (var element in dir.Contents)
        {
            if (element is Directory subDir)
            {
                GetLargeDirs(subDir, largeDirs, size);
            }
        }
    }
}

public interface IElement
{
    Directory Parent { get; set; }
    string Name { get; set; }

    int GetSize();
}

public class Directory : IElement
{
    public Directory Parent { get; set; }
    public string Name { get; set; }
    public List<IElement> Contents { get; } = new();

    public int GetSize()
    {
        return Contents.Sum(x => x.GetSize());
    }
}

public class File : IElement
{
    public Directory Parent { get; set; }
    public string Name { get; set; }
    public int Size { get; set; }

    public int GetSize()
    {
        return Size;
    }
}