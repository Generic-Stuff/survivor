using Game.Utils.GenericLogs;
using Geme.Utils.WaveMachineGenerics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveMachine : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    public MachineScriptable machineScriptable;

    #region Variables
    public int currentLevel = 0;
    private float currentTime = 0f;

    public TextMeshProUGUI counterLabel;
    public TextMeshProUGUI levelLabel;

    #endregion
    private void Start()
    {
        ILevelData levelData = WaveMachineGenerics.GetLevel(currentLevel);
        machineScriptable.LoadFrom(levelData);
        levelLabel.text = "Level: " + machineScriptable.Level.ToString();
        UpdateTimerUI();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        counterLabel.text = $"Time: {minutes:00}:{seconds:00}";
    }
}
