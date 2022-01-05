using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : Singleton<TimeManager>
{
    #region VARIABLES
    private const string TimespanPattern = @"mm\:ss";
    private const int MaxMinutes = 60;
    private const int StartingTime = 0;
    private const float DecreasingTimeInSeconds = 1f;
    
    public static Action<string> OnTimeChange;

    private int timeInSeconds;
    private Coroutine timeCoroutine;
    #endregion
    
    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoad;

    private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoad;
    #endregion
    
    #region CLASS METHODS
    public void InitTime()
    {
        if (timeCoroutine == null)
        {
            timeInSeconds = StartingTime;
        }
        
        timeCoroutine = StartCoroutine(StartTime());
    }
    
    public void StopTime() => StopCoroutine(timeCoroutine);

    private IEnumerator StartTime()
    {
        var minutesFromSeconds = TimeSpan.FromSeconds(timeInSeconds).Minutes;

        while (minutesFromSeconds <= MaxMinutes)
        {
            OnTimeChange?.Invoke(TimeInSecondsToString(++timeInSeconds));

            minutesFromSeconds = TimeSpan.FromSeconds(timeInSeconds).Minutes;

            yield return new WaitForSeconds(DecreasingTimeInSeconds);
        }
    }
    
    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        var isFirstScene = scene.buildIndex == 0;
        
        if (isFirstScene) return;
        
        OnTimeChange?.Invoke(TimeInSecondsToString(timeInSeconds));
    }

    private string TimeInSecondsToString(int timeInSeconds) => TimeSpan.FromSeconds(timeInSeconds).ToString(TimespanPattern);
    #endregion
}
