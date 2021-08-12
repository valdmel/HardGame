using System;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region VARIABLES
    private const string TIMESPAN_PATTERN = @"mm\:ss";
    private const float DECREASING_TIME_IN_SECONDS = 1f;
    private const int MAX_MINUTES = 60;
    private const int STARTING_TIME = 0;
    private const float GAME_DEFAULT_TIMESCALE = 1f;

    public static Action OnGamePause;
    public static Action<string> OnDeathCounterChange;
    public static Action<string> OnTimeChange;

    private bool isGamePaused = false;
    private int deathCounter = 0;
    private int seconds;
    private Coroutine timerCoroutine;

    public bool IsGamePaused { get => isGamePaused; private set => isGamePaused = value; }
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => PlayerBody.OnPlayerDeath += UpdateDeathCounter;

    private void OnDisable() => PlayerBody.OnPlayerDeath -= UpdateDeathCounter;
    #endregion

    #region CLASS METHODS
    public void InitTimer()
    {
        seconds = STARTING_TIME;
        timerCoroutine = StartCoroutine(StartTimer());
    }

    public void StopTimer()
    {
        StopCoroutine(timerCoroutine);

        timerCoroutine = null;
    }

    public void PauseGame()
    {
        var pauseTimeScale = GAME_DEFAULT_TIMESCALE - Time.timeScale;
        isGamePaused = !isGamePaused;

        OnGamePause?.Invoke();
        Time.timeScale = pauseTimeScale;
    }

    private IEnumerator StartTimer()
    {
        var minutesFromSeconds = TimeSpan.FromSeconds(seconds).Minutes;

        while (minutesFromSeconds <= MAX_MINUTES)
        {
            OnTimeChange?.Invoke(ConvertSeconds(++seconds));

            minutesFromSeconds = TimeSpan.FromSeconds(seconds).Minutes;

            yield return new WaitForSeconds(DECREASING_TIME_IN_SECONDS);
        }

        StopTimer();
    }

    private void UpdateDeathCounter()
    {
        ++deathCounter;

        OnDeathCounterChange?.Invoke(deathCounter.ToString());
    }

    private string ConvertSeconds(int seconds) => TimeSpan.FromSeconds(seconds).ToString(TIMESPAN_PATTERN);
    #endregion
}