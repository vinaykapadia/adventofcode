using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdventOfCode._2015.Day12;

[ProblemName("JSAbacusFramework.io")]      
internal class Solution : Solver {

    public object PartOne(string input) {
        dynamic data = JsonConvert.DeserializeObject(input);
        return CountNoRed(data, false);
    }

    public object PartTwo(string input) {
        dynamic data = JsonConvert.DeserializeObject(input);
        return CountNoRed(data, true);
    }

    private static long CountNoRed(dynamic data, bool filterRed)
    {
        var sum = 0;

        var hasRed = false;
        if (filterRed && (data.Type == null || data.Type == JTokenType.Object))
        {
            foreach (var item in data)
            {
                if (item.Type == JTokenType.Property && item.Value.ToString() == "red")
                {
                    hasRed = true;
                    break;
                }
            }
        }

        if (hasRed)
        {
            return sum;
        }

        if (data.Type == JTokenType.Array || data.Type == null || data.Type == JTokenType.Object)
            foreach (var item in data)
            {
                sum += CountNoRed(item, filterRed);
            }

        if (data.Type == JTokenType.Property)
        {
            sum += CountNoRed(data.Value, filterRed);
        }

        if (data.Type == JTokenType.Integer)
        {
            sum += data.Value;
        }

        return sum;
    }
}
