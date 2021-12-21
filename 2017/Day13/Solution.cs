using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AdventOfCode._2017.Day13;

[ProblemName("Packet Scanners")]      
internal class Solution : ISolver
{
    private readonly Dictionary<int, Layer> _firewall = new();

    public object PartOne(string input)
    {
        foreach (var line in input.Lines())
        {
            int layer = int.Parse(line.Substring(0, line.IndexOf(':')));
            int depth = int.Parse(line.Substring(line.IndexOf(' ') + 1));

            _firewall.Add(layer, new Layer(depth));
        }

        int firewallSize = _firewall.Max(x => x.Key);

        int severity = 0;
        for (int currentLayer = 0; currentLayer <= firewallSize; currentLayer++)
        {
            if (_firewall.ContainsKey(currentLayer) && _firewall[currentLayer].ScannerLocation == 0) // caught
            {
                severity += currentLayer * _firewall[currentLayer].Range;
            }

            foreach (var layer in _firewall) layer.Value.AdvanceScanner();
        }

        return severity;
    }

    public object PartTwo(string input)
    {
        int firewallSize = _firewall.Max(x => x.Key);
        
        for (int delay = 1; ; delay++)
        {
            var caught = false;
            for (var i = 0; !caught && i <= firewallSize; i++)
            {
                if (!_firewall.ContainsKey(i)) continue;;
                _firewall[i].ResetScanner();
                _firewall[i].AdvanceScanner(delay + i);
                if (_firewall[i].ScannerLocation == 0) caught = true;
            }

            if (!caught)
            {
                return delay;
            }
        }
    }

    class Layer
    {
        public int Range { get; }

        public int ScannerLocation { get; private set; }

        private int direction;

        public Layer(int range)
        {
            Range = range;
            ResetScanner();
        }

        public void ResetScanner()
        {
            ScannerLocation = 0;
            direction = 1;
        }

        public void AdvanceScanner(int steps)
        {
            int cycleSize = Range * 2 - 2;
            for (int i = 0; i < steps % cycleSize; i++) AdvanceScanner();
        }

        public void AdvanceScanner()
        {
            ScannerLocation += direction;
            if (ScannerLocation == Range)
            {
                ScannerLocation -= 2;
                direction = -1;
            }
            else if (ScannerLocation == -1)
            {
                ScannerLocation += 2;
                direction = 1;
            }
        }
    }
}
