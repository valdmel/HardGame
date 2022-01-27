using System;
using TMPro;
using UnityEngine;

public class GameEndStats : MonoBehaviour
{
    #region VARIABLES
    private const string deathText = "Deaths: ";
    private const string timeText = "Time: ";
    private const string TimespanPattern = @"mm\:ss";
    
    #region SERIALIZABLE
    [Header("Text Properties")]
    [SerializeField] private TMP_Text deathCounterText;
    [SerializeField] private TMP_Text timerText;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start()
    {
        timerText.gameObject.SetActive(!GameManager.Instance.IsNormalGameModeActive);
        ShowGameStats();
    }

    #endregion
    
    #region CLASS METHODS
    private void ShowGameStats()
    {
        deathCounterText.text = deathText + GameManager.Instance.DeathCounter;

        if (GameManager.Instance.IsNormalGameModeActive) return;

        var time = TimeSpan.FromSeconds(TimeManager.Instance.TimeInSeconds).ToString(TimespanPattern);
        timerText.text = timeText + time;
    }
    #endregion
}
