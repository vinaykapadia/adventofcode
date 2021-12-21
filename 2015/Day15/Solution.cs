using System.Collections.Generic;

namespace AdventOfCode._2015.Day15;

[ProblemName("Science for Hungry People")]      
internal class Solution : ISolver {
    // I just typed the input data into here, easier than parsing.
    private readonly Dictionary<string, Dictionary<string, int>> _ingredients = new()
    {
        {
            "Sprinkles", new Dictionary<string, int>
            {
                {"Capacity", 5},
                {"Durability", -1},
                {"Flavor", 0},
                {"Texture", 0},
                {"Calories", 5}
            }
        },
        {
            "PeanutButter", new Dictionary<string, int>
            {
                {"Capacity", -1},
                {"Durability", 3},
                {"Flavor", 0},
                {"Texture", 0},
                {"Calories", 1}
            }
        },
        {
            "Frosting", new Dictionary<string, int>
            {
                {"Capacity", 0},
                {"Durability", -1},
                {"Flavor", 4},
                {"Texture", 0},
                {"Calories", 6}
            }
        },
        {
            "Sugar", new Dictionary<string, int>
            {
                {"Capacity", -1},
                {"Durability", 0},
                {"Flavor", 0},
                {"Texture", 2},
                {"Calories", 8}
            }
        }
    };

    public object PartOne(string input) {
        var maxScore = 0;

        for (var sp = 0; sp <= 100; sp++)
        for (var pb = 0; pb <= 100; pb++)
        for (var fr = 0; fr <= 100; fr++)
        for (var su = 0; su <= 100; su++)
        {
            if (sp + pb + fr + su != 100) continue;

            var cap = sp * _ingredients["Sprinkles"]["Capacity"] + pb * _ingredients["PeanutButter"]["Capacity"] + fr * _ingredients["Frosting"]["Capacity"] + su * _ingredients["Sugar"]["Capacity"];
            if (cap < 0) cap = 0;

            var dur = sp * _ingredients["Sprinkles"]["Durability"] + pb * _ingredients["PeanutButter"]["Durability"] + fr * _ingredients["Frosting"]["Durability"] + su * _ingredients["Sugar"]["Durability"];
            if (dur < 0) dur = 0;

            var fla = sp * _ingredients["Sprinkles"]["Flavor"] + pb * _ingredients["PeanutButter"]["Flavor"] + fr * _ingredients["Frosting"]["Flavor"] + su * _ingredients["Sugar"]["Flavor"];
            if (fla < 0) fla = 0;

            var tex = sp * _ingredients["Sprinkles"]["Texture"] + pb * _ingredients["PeanutButter"]["Texture"] + fr * _ingredients["Frosting"]["Texture"] + su * _ingredients["Sugar"]["Texture"];
            if (tex < 0) tex = 0;

            var score = cap * dur * fla * tex;
            if (score > maxScore)
            {
                maxScore = score;
            }
        }

        return maxScore;
    }

    public object PartTwo(string input) {
        var maxScore = 0;

        for (var sp = 0; sp <= 100; sp++)
        for (var pb = 0; pb <= 100; pb++)
        for (var fr = 0; fr <= 100; fr++)
        for (var su = 0; su <= 100; su++)
        {
            if (sp + pb + fr + su != 100) continue;

            // This is only for Part B
            var cal = sp * _ingredients["Sprinkles"]["Calories"] + pb * _ingredients["PeanutButter"]["Calories"] + fr * _ingredients["Frosting"]["Calories"] + su * _ingredients["Sugar"]["Calories"];
            if (cal != 500) continue;

            var cap = sp * _ingredients["Sprinkles"]["Capacity"] + pb * _ingredients["PeanutButter"]["Capacity"] + fr * _ingredients["Frosting"]["Capacity"] + su * _ingredients["Sugar"]["Capacity"];
            if (cap < 0) cap = 0;

            var dur = sp * _ingredients["Sprinkles"]["Durability"] + pb * _ingredients["PeanutButter"]["Durability"] + fr * _ingredients["Frosting"]["Durability"] + su * _ingredients["Sugar"]["Durability"];
            if (dur < 0) dur = 0;

            var fla = sp * _ingredients["Sprinkles"]["Flavor"] + pb * _ingredients["PeanutButter"]["Flavor"] + fr * _ingredients["Frosting"]["Flavor"] + su * _ingredients["Sugar"]["Flavor"];
            if (fla < 0) fla = 0;

            var tex = sp * _ingredients["Sprinkles"]["Texture"] + pb * _ingredients["PeanutButter"]["Texture"] + fr * _ingredients["Frosting"]["Texture"] + su * _ingredients["Sugar"]["Texture"];
            if (tex < 0) tex = 0;

            var score = cap * dur * fla * tex;
            if (score > maxScore)
            {
                maxScore = score;
            }
        }

        return maxScore;
    }
}
