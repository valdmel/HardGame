using System;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region VARIABLES
    private const string TIMESPAN_PATTERN = @"mm\:ss";
    private const int MAX_MINUTES = 60;
    private const int STARTING_TIME = 0;
    private const float DECREASING_TIME_IN_SECONDS = 1f;

    public static Action<string> onDeathCounterChange;
    public static Action<string> onTimeChange;
    public static Action onGamePause;
    public static Action onTimeMax;

    private bool isGamePaused = false;
    private int deathCounter = 0;
    private int timeInSeconds;
    private Coroutine timeCoroutine;

    public bool IsGamePaused { get => isGamePaused; set => isGamePaused = value; }
    public int DeathCounter { get => deathCounter; private set => deathCounter = value; }
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => PlayerBody.onPlayerDeath += OnDeath;

    private void OnDisable() => PlayerBody.onPlayerDeath -= OnDeath;
    #endregion

    #region CLASS METHODS
    public void InitTime()
    {
        timeInSeconds = STARTING_TIME;
        timeCoroutine = StartCoroutine(StartTime());
    }

    public void StopTime()
    {
        StopCoroutine(timeCoroutine);

        timeCoroutine = null;
    }

    public void PauseGame() => onGamePause?.Invoke();

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

    private void OnDeath()
    {
        StopTime();
        UpdateDeathCounter();
    }

    private void UpdateDeathCounter() => onDeathCounterChange?.Invoke((++deathCounter).ToString());

    private string TimeInSecondsToString(int timeInSeconds) => TimeSpan.FromSeconds(timeInSeconds).ToString(TIMESPAN_PATTERN);
    #endregion
}