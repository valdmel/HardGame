using System;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region VARIABLES
    private const string TIME_TEXT_PATTERN = @"hh\:mm\:ss";

    #region SERIALIZABLE
    [Header("HUD Properties")]
    [SerializeField] private TMP_Text timerText;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => GameManager.OnTimeChange += DisplayTime;

    private void OnDisable() => GameManager.OnTimeChange -= DisplayTime;
    #endregion

    #region CLASS METHODS
    public void DisplayTime(string timeString) => timerText.text = timeString;
    #endregion
}
