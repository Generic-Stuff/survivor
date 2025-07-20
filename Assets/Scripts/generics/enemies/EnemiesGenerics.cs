using Game.Utils.GenericLogs;
using Geme.Utils.WaveMachineGenerics;
using UnityEngine;

namespace Game.Utils.EnemiesGenerics
{
    public interface IEnemiesData
    {
        string name { get; }
        int maxHealth { get; }
        int maxDamaged { get; }
        int maxMana { get; }

    }

    public class DwarfEnemy : IEnemiesData
    {

        public string name => "Dwarft";
        public int maxHealth => 100;
        public int maxDamaged => 2;
        public int maxMana => 100;
    }

    public class TrollEnemy : IEnemiesData
    {

        public string name => "Troll";
        public int maxHealth => 150;
        public int maxDamaged => 15;
        public int maxMana => 50;
    }

    public class ZoddsEnemy : IEnemiesData
    {

        public string name => "Zodds";
        public int maxHealth => 300;
        public int maxDamaged => 30;
        public int maxMana => 50;
    }

    public class EnemiesGenerics
    {
        public static IEnemiesData getEnemyByLevel(int level)
        {
            switch (level)
            {
                case 1: return new DwarfEnemy();
                case 2: return new TrollEnemy();
                case 3: return new ZoddsEnemy();
                default:
                    Debug.LogWarning(GenericLogMessages.LevelIsnotDefined);
                    return new DwarfEnemy();
            }
        }
    }

}