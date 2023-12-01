namespace AdventOfCode._2022.Day20;

[ProblemName("Grove Positioning System")]      
internal class Solution : ISolver
{
    List<KeyValuePair<int, long>> list;

    public object PartOne(string input)
    {
        list = new();
        var lines = input.Lines();
        for(var i = 0; i < lines.Length; i++)
        {
            list.Add(new KeyValuePair<int, long>(i, int.Parse(lines[i])));
        }

        for (var i = 0; i < list.Count; i++)
        {
            var index = list.IndexOf(list.Find(x => x.Key == i));
            var steps = list[index].Value;
            var direction = steps < 0 ? -1 : 1;
            steps *= direction;
            //steps %= list.Count - 1;
            
            if (direction > 0)
            {
                for (var j = 0; j < steps; j++)
                {
                    MoveForward(index);
                    index++;
                    index %= list.Count;
                }
            }
            else
            {
                for (var j = 0; j < steps; j++)
                {
                    MoveBackward(index);
                    index--;
                    index += list.Count;
                    index %= list.Count;
                }
            }
        }

        var zeroIndex = list.IndexOf(list.Find(x => x.Value == 0));

        return list[(zeroIndex + 1000) % list.Count].Value + list[(zeroIndex + 2000) % list.Count].Value + list[(zeroIndex + 3000) % list.Count].Value;
    }

    public object PartTwo(string input)
    {
        return 0;
        /* This isn't working.
        long decryptionKey = 811589153;
        list = new();
        var lines = input.Lines();
        for (var i = 0; i < lines.Length; i++)
        {
            list.Add(new KeyValuePair<int, long>(i, long.Parse(lines[i]) * decryptionKey));
        }

        for (var i = 0; i < list.Count; i++)
        {
            var index = list.IndexOf(list.Find(x => x.Key == i));
            var steps = list[index].Value;
            var direction = steps < 0 ? -1 : 1;
            steps *= direction;
            if (direction > 0)
            {
                for (long j = 0; j < steps; j++)
                {
                    MoveForward(index);
                    index++;
                    index %= list.Count;
                }
            }
            else
            {
                for (long j = 0; j < steps; j++)
                {
                    MoveBackward(index);
                    index--;
                    index += list.Count;
                    index %= list.Count;
                }
            }
        }

        var zeroIndex = list.IndexOf(list.Find(x => x.Value == 0));

        return list[zeroIndex + 1000 % list.Count].Value + list[zeroIndex + 2000 % list.Count].Value + list[zeroIndex + 3000 % list.Count].Value;*/
    }

    private void MoveForward(int index)
    {
        var nextIndex = index + 1;
        if (nextIndex == list.Count) 
        {
            nextIndex = 0;
        }

        var temp = list[nextIndex];
        list[nextIndex] = list[index];
        list[index] = temp;
    }

    private void MoveBackward(int index)
    {
        var nextIndex = index - 1;
        if (nextIndex < 0)
        {
            nextIndex = list.Count - 1;
        }

        var temp = list[nextIndex];
        list[nextIndex] = list[index];
        list[index] = temp;
    }
}
