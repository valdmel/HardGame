using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    #region VARIABLES
    private const string TIMESPAN_PATTERN = @"mm\:ss";
    private const int MAX_MINUTES = 60;
    private const int STARTING_TIME = 0;
    private const float DECREASING_TIME_IN_SECONDS = 1f;

    private enum GameMode
    {
        NORMAL = 0,
        SPEEDRUN = 1
    }

    public static Action<string> onDeathCounterChange;
    public static Action<string> onTimeChange;
    public static Action onGamePause;
    public static Action onTimeMax;

    private int activeGameMode;
    private int deathCounter = 0;
    private int timeInSeconds;
    private bool isGamePaused = false;
    private Coroutine timeCoroutine;

    public bool IsGamePaused { get => isGamePaused; set => isGamePaused = value; }
    public int ActiveGameMode { get => activeGameMode; set => activeGameMode = value; }
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        PlayerBody.onPlayerTouchBomb += UpdateDeathCounter;
        PlayerBody.onPlayerTouchSuperBomb += UpdateDeathCounter;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
        PlayerBody.onPlayerTouchBomb -= UpdateDeathCounter;
        PlayerBody.onPlayerTouchSuperBomb -= UpdateDeathCounter;
    }
    #endregion

    #region CLASS METHODS
    public void StartLevel()
    {
        var canActivateTimer = !IsNormalGameModeActive() && timeCoroutine == null;

        if (canActivateTimer) InitTime();

        onDeathCounterChange?.Invoke(deathCounter.ToString());
    }

    public void InitTime()
    {
        timeInSeconds = STARTING_TIME;
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

    public void ActivateNormalGameMode() => activeGameMode = (int)GameMode.NORMAL;

    public void ActivateSpeedrunGameMode() => activeGameMode = (int)GameMode.SPEEDRUN;

    public void PauseGame() => onGamePause?.Invoke();

    public bool IsNormalGameModeActive() => activeGameMode.Equals((int)GameMode.NORMAL);

    private IEnumerator StartTime()
    {
        var minutesFromSeconds = TimeSpan.FromSeconds(timeInSeconds).Minutes;

        while (minutesFromSeconds <= MAX_MINUTES)
        {
            onTimeChange?.Invoke(TimeInSecondsToString(++timeInSeconds));

            minutesFromSeconds = TimeSpan.FromSeconds(timeInSeconds).Minutes;

            yield return new WaitForSeconds(DECREASING_TIME_IN_SECONDS);
        }

        onTimeMax?.Invoke();
    }

    private void UpdateDeathCounter() => onDeathCounterChange?.Invoke((++deathCounter).ToString());

    private string TimeInSecondsToString(int timeInSeconds) => TimeSpan.FromSeconds(timeInSeconds).ToString(TIMESPAN_PATTERN);

    private void OnSceneLoad(Scene scene, LoadSceneMode mode) => onDeathCounterChange?.Invoke(deathCounter.ToString());
    #endregion
}