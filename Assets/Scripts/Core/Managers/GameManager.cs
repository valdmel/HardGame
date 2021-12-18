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

    private enum GameMode
    {
        Normal = 0,
        Speedrun = 1
    }

    public static Action<string> OnDeathCounterChange;
    public static Action<string> OnTimeChange;
    public static Action OnGamePause;
    public static Action OnTimeMax;

    private int activeGameMode;
    private int deathCounter;
    private int timeInSeconds;
    private Coroutine timeCoroutine;

    public bool IsGamePaused { get; set; }
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
    public void StartLevel()
    {
        var canActivateTimer = !IsNormalGameModeActive() && timeCoroutine == null;

        if (canActivateTimer) InitTime();

        OnDeathCounterChange?.Invoke(deathCounter.ToString());
    }

    public void InitTime()
    {
        timeInSeconds = StartingTime;
        timeCoroutine = StartCoroutine(StartTime());
    }

    public void StopTime()
    {
        if (IsNormalGameModeActive())
        {
            StopCoroutine(timeCoroutine);

            timeCoroutine = null;
        }
    }

    public void ActivateNormalGameMode() => activeGameMode = (int)GameMode.Normal;

    public void ActivateSpeedrunGameMode() => activeGameMode = (int)GameMode.Speedrun;

    public void PauseGame() => OnGamePause?.Invoke();

    public bool IsNormalGameModeActive() => activeGameMode.Equals((int)GameMode.Normal);

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

    private void OnSceneLoad(Scene scene, LoadSceneMode mode) => OnDeathCounterChange?.Invoke(deathCounter.ToString());
    #endregion
}