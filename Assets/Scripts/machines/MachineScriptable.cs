using Geme.Utils.WaveMachineGenerics;
using UnityEngine;

[CreateAssetMenu(fileName = "MachineScriptable", menuName = "Scriptable Objects/MachineScriptable")]
public class MachineScriptable : ScriptableObject
{
    public string LevelName;
    public int Level;
    public int MaxWaveTime;
    public int SpawnTime;
    public int MaxSpawnCountPerLevel;

    public void LoadFrom(ILevelData levelData)
    {
        LevelName = levelData.LevelName;
        Level = levelData.Level;
        MaxWaveTime = levelData.MaxWaveTime;
        SpawnTime = levelData.SpawnTime;
        MaxSpawnCountPerLevel = levelData.MaxSpawnCountPerLevel;
    }
}
