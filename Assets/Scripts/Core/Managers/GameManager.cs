using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    #region VARIABLES
    private const string TimespanPattern = @"mm\:ss";
    private const int MaxMinutes = 60;
    private const int StartingTime = 0;
    private const float DecreasingTimeInSeconds = 1f;

    public static Action<string> OnDeathCounterChange;
    public static Action<string> OnTimeChange;
    public static Action OnGamePause;
    public static Action OnTimeMax;
    
    private int deathCounter;
    private int timeInSeconds;
    private Coroutine timeCoroutine;
    
    public int ActiveGameMode { get; set; }
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        PlayerBody.OnPlayerTouchBomb += UpdateDeathCounter;
        PlayerBody.OnPlayerTouchSuperBomb += UpdateDeathCounter;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
        PlayerBody.OnPlayerTouchBomb -= UpdateDeathCounter;
        PlayerBody.OnPlayerTouchSuperBomb -= UpdateDeathCounter;
    }
    #endregion

    #region CLASS METHODS
    public void StopTime()
    {
        if (IsNormalGameModeActive()) return;
        
        StopCoroutine(timeCoroutine);
    }
    
    public void StartLevel() => InitTime();

    public void PauseGame() => OnGamePause?.Invoke();

    public bool IsNormalGameModeActive() => ActiveGameMode == (int)GameModeIndex.Normal;
    
    private void InitTime()
    {
        if (IsNormalGameModeActive()) return;

        if (timeCoroutine == null)
        {
            timeInSeconds = StartingTime;
        }
        
        timeCoroutine = StartCoroutine(StartTime());
    }
    
    private IEnumerator StartTime()
    {
        var minutesFromSeconds = TimeSpan.FromSeconds(timeInSeconds).Minutes;

        while (minutesFromSeconds <= MaxMinutes)
        {
            OnTimeChange?.Invoke(TimeInSecondsToString(++timeInSeconds));

            minutesFromSeconds = TimeSpan.FromSeconds(timeInSeconds).Minutes;

            yield return new WaitForSeconds(DecreasingTimeInSeconds);
        }

        OnTimeMax?.Invoke();
    }

    private void UpdateDeathCounter() => OnDeathCounterChange?.Invoke((++deathCounter).ToString());

    private string TimeInSecondsToString(int timeInSeconds) => TimeSpan.FromSeconds(timeInSeconds).ToString(TimespanPattern);

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (!IsNormalGameModeActive())
        {
            OnTimeChange?.Invoke(TimeInSecondsToString(timeInSeconds));
        }

        OnDeathCounterChange?.Invoke(deathCounter.ToString());
    }

    private void OnApplicationQuit() => PlayerPrefs.DeleteAll();
    #endregion
}