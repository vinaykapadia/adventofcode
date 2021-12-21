using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2015.Day21;

// Values from input were just typed directly in.

[ProblemName("RPG Simulator 20XX")]      
internal class Solution : ISolver {
    private class Item
    {
        public int Cost { get; init; }
        public int ArmorBonus { get; init; }
        public int DamageBonus { get; init; }
    }

    private class Ring : Item
    {
    }
    private class Weapon : Item
    {
    }
    private class Armor : Item
    {
    }

    private class Creature
    {
        private int _baseDamage;
        private int _baseArmor;
        private readonly List<Ring> _rings = new List<Ring>();

        public Creature(int startHitPoints, int baseDamage, int baseArmor)
        {
            _baseDamage = baseDamage;
            _baseArmor = baseArmor;
            HitPoints = startHitPoints;
            GoldSpent = 0;
        }

        public int HitPoints { get; set; }
        public int Damage => _baseDamage + _rings.Sum(x => x.DamageBonus);
        public int ArmorClass => _baseArmor + _rings.Sum(x => x.ArmorBonus);
        public int GoldSpent { get; private set; }

        public void Wear(Ring r)
        {
            if (_rings.Count < 2)
            {
                _rings.Add(r);
                Charge(r);
            }
        }

        public void Wield(Weapon w)
        {
            _baseDamage = w.DamageBonus;
            Charge(w);
        }

        public void Don(Armor a)
        {
            _baseArmor = a.ArmorBonus;
            Charge(a);
        }

        private void Charge(Item i)
        {
            GoldSpent += i.Cost;
        }
    }

    private static int _count = 1;
    private static int _totalCount;

    public static int PartBAnswer { get; set; }

    public object PartOne(string input) {
        var weapons = new Weapon[5];
        InitWeapons(weapons);

        var armors = new Armor[6];
        InitArmors(armors);

        var rings = new Ring[6];
        InitRings(rings);

        var allPlayers = new List<Creature>();

        for (var w = 0; w < 5; w++)
        {
            for (var a = 0; a < 6; a++)
            {
                //0 rings
                var player = new Creature(100, 0, 0);
                player.Wield(weapons[w]);
                player.Don(armors[a]);
                allPlayers.Add(player);

                //1 ring
                for (var r = 0; r < 6; r++)
                {
                    player = new Creature(100, 0, 0);
                    player.Wield(weapons[w]);
                    player.Don(armors[a]);
                    player.Wear(rings[r]);
                    allPlayers.Add(player);
                }

                //2 rings
                for (var r1 = 0; r1 < 6; r1++)
                {
                    for (var r2 = r1 + 1; r2 < 6; r2++)
                    {
                        player = new Creature(100, 0, 0);
                        player.Wield(weapons[w]);
                        player.Don(armors[a]);
                        player.Wear(rings[r1]);
                        player.Wear(rings[r2]);
                        allPlayers.Add(player);
                    }
                }
            }
        }

        _totalCount = allPlayers.Count;
        foreach (var eachPlayer in allPlayers)
        {
            DoBattle(eachPlayer, new Creature(109, 8, 2));
        }

        PartBAnswer = allPlayers.Where(x => x.HitPoints <= 0).Max(x => x.GoldSpent);
        return allPlayers.Where(x => x.HitPoints > 0).Min(x => x.GoldSpent);
    }

    public object PartTwo(string input)
    {
        return PartBAnswer;
    }

    private static void DoBattle(Creature player, Creature boss)
    {
        _count++;

        while (true)
        {
            // Player Turn
            int damage = player.Damage - boss.ArmorClass;
            if (damage < 1) damage = 1;
            boss.HitPoints -= damage;
            if (boss.HitPoints <= 0) return;

            // Boss Turn
            damage = boss.Damage - player.ArmorClass;
            if (damage < 1) damage = 1;
            player.HitPoints -= damage;
            if (player.HitPoints <= 0) return;
        }
    }

    private static void InitRings(Ring[] rings)
    {
        rings[0] = new Ring
        {
            ArmorBonus = 1,
            Cost = 20
        };
        rings[1] = new Ring
        {
            ArmorBonus = 2,
            Cost = 40
        };
        rings[2] = new Ring
        {
            ArmorBonus = 3,
            Cost = 80
        };
        rings[3] = new Ring
        {
            DamageBonus = 1,
            Cost = 25
        };
        rings[4] = new Ring
        {
            DamageBonus = 2,
            Cost = 50
        };
        rings[5] = new Ring
        {
            DamageBonus = 3,
            Cost = 100
        };
    }

    private static void InitArmors(Armor[] armors)
    {
        armors[0] = new Armor
        {
            ArmorBonus = 1,
            Cost = 13
        };
        armors[1] = new Armor
        {
            ArmorBonus = 2,
            Cost = 31
        };
        armors[2] = new Armor
        {
            ArmorBonus = 3,
            Cost = 53
        };
        armors[3] = new Armor
        {
            ArmorBonus = 4,
            Cost = 75
        };
        armors[4] = new Armor
        {
            ArmorBonus = 5,
            Cost = 102
        };
        armors[5] = new Armor
        {
            ArmorBonus = 0,
            Cost = 0
        };
    }

    private static void InitWeapons(Weapon[] weapons)
    {
        weapons[0] = new Weapon
        {
            DamageBonus = 4,
            Cost = 8
        };
        weapons[1] = new Weapon
        {
            DamageBonus = 5,
            Cost = 10
        };
        weapons[2] = new Weapon
        {
            DamageBonus = 6,
            Cost = 25
        };
        weapons[3] = new Weapon
        {
            DamageBonus = 7,
            Cost = 40
        };
        weapons[4] = new Weapon
        {
            DamageBonus = 8,
            Cost = 74
        };
    }
}
