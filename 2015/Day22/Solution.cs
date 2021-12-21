using System;

namespace AdventOfCode._2015.Day22;

// Values from input are just typed in.

[ProblemName("Wizard Simulator 20XX")]      
internal class Solution : ISolver {
    private struct Player
    {
        public int HitPoints;
        public int Mana;
        public int ManaSpent;
        public int Recharge;
        public int Shield;
    }

    private struct Boss
    {
        public int HitPoints;
        public int Damage;
        public int Poison;
    }

    private static int _minMana;
    private static readonly int[] SpellCosts = { 53, 73, 113, 173, 229 };
    private static bool _hardMode;

    private readonly Boss _boss = new()
    {
        HitPoints = 58,
        Damage = 9,
        Poison = 0
    };

    private readonly Player _player = new()
    {
        HitPoints = 50,
        Mana = 500,
        ManaSpent = 0,
        Recharge = 0,
        Shield = 0
    };

    public object PartOne(string input) {
        _hardMode = false;
        _minMana = 5000;
        for (var i = 0; i < 5; i++)
        {
            DoTurn(_player, _boss, i);
        }

        return _minMana;
    }

    public object PartTwo(string input) {
        _hardMode = true;
        _minMana = 5000;
        for (var i = 0; i < 5; i++)
        {
            DoTurn(_player, _boss, i);
        }

        return _minMana;
    }

    private static void DoTurn(Player player, Boss boss, int spell, bool playerTurn = true)
    {
        // Do Effects
        if (player.Shield > 0)
        {
            player.Shield--;
        }
        if (player.Recharge > 0)
        {
            player.Mana += 101;
            player.Recharge--;
        }
        if (boss.Poison > 0)
        {
            boss.HitPoints -= 3;
            boss.Poison--;
        }
        if (_hardMode && playerTurn)
        {
            player.HitPoints--;
        }

        //Check for deaths
        if (player.HitPoints <= 0) return;
        if (boss.HitPoints <= 0)
        {
            _minMana = Math.Min(_minMana, player.ManaSpent);
            return;
        }

        if (playerTurn)
        {
            if (player.Mana < SpellCosts[spell])
            {
                return;
            }

            player.Mana -= SpellCosts[spell];
            player.ManaSpent += SpellCosts[spell];
            switch (spell)
            {
                case 0: //Magic Missile
                    boss.HitPoints -= 4;
                    break;
                case 1: //Drain
                    boss.HitPoints -= 2;
                    player.HitPoints += 2;
                    break;
                case 2: //Shield
                    if (player.Shield > 0) return;
                    player.Shield = 6;
                    break;
                case 3: //Poison
                    if (boss.Poison > 0) return;
                    boss.Poison = 6;
                    break;
                case 4: //Recharge
                    if (player.Recharge > 0) return;
                    player.Recharge = 5;
                    break;
            }
        }
        else
        {
            if (player.Shield > 0) player.HitPoints += 7;
            player.HitPoints -= boss.Damage;
        }

        //Check for done
        if (player.HitPoints <= 0) return;
        if (boss.HitPoints <= 0)
        {
            _minMana = Math.Min(_minMana, player.ManaSpent);
            return;
        }
        if (player.ManaSpent > _minMana) return;

        if (playerTurn)
        {
            DoTurn(player, boss, 0, false);
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                DoTurn(player, boss, i);
            }
        }
    }
}
