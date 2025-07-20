using UnityEngine;
using Game.Utils.GenericLogs;
using Game.Utils.EnemiesGenerics;

namespace Geme.Utils.WaveMachineGenerics
{
    public interface ILevelData
    {
        string LevelName { get; }
        int Level { get; }
        int MaxWaveTime { get; }
        int SpawnTime { get; }
        int MaxSpawnCountPerLevel { get; }
    }

    public class LevelOne : ILevelData
    {
        public string LevelName => EnemiesGenerics.getEnemyByLevel(1).name;
        public int Level => 1;
        public int MaxWaveTime => 10;
        public int SpawnTime => 6;
        public int MaxSpawnCountPerLevel => 25;
    }

    public class LevelTwo : ILevelData
    {
        public string LevelName => EnemiesGenerics.getEnemyByLevel(2).name;
        public int Level => 2;
        public int MaxWaveTime => 12;
        public int SpawnTime => 5;
        public int MaxSpawnCountPerLevel => 30;
    }

    public class LevelThree : ILevelData
    {
        public string LevelName => EnemiesGenerics.getEnemyByLevel(3).name;
        public int Level => 3;
        public int MaxWaveTime => 14;
        public int SpawnTime => 4;
        public int MaxSpawnCountPerLevel => 35;
    }

    public class WaveMachineGenerics
    {
        public static ILevelData GetLevel(int level)
        {
            switch (level)
            {
                case 1: return new LevelOne();
                case 2: return new LevelTwo();
                case 3: return new LevelThree();
                default:
                    Debug.LogWarning(GenericLogMessages.LevelIsnotDefined);
                    return new LevelOne();
            }
        }
    }

}