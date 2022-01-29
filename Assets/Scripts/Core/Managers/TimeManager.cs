using System;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class TimeManager : Singleton<TimeManager>
{
    #region VARIABLES
    public static Action<string> OnElapsedTime;
    
    private readonly Stopwatch stopwatch = new Stopwatch();
    
    public string ElapsedTime => $"{TimeTaken.Hours:00}:{TimeTaken.Minutes:00}:{TimeTaken.Seconds:00}";
    private TimeSpan TimeTaken => stopwatch.Elapsed;
    #endregion
    
    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        GamePause.OnGameResume += StartTime;
        GamePause.OnGamePause += StopTime;
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void Update()
    {
        if (!stopwatch.IsRunning) return;
        
        OnElapsedTime?.Invoke(ElapsedTime);
    }

    private void OnDisable()
    {
        GamePause.OnGameResume -= StartTime;
        GamePause.OnGamePause -= StopTime;
        SceneManager.sceneLoaded -= OnSceneLoad;
    }

    #endregion
    
    #region CLASS METHODS
    public void StartTime() => stopwatch?.Start();

    public void StopTime() => stopwatch?.Stop();

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.IsFirst()) return;
        
        OnElapsedTime?.Invoke(ElapsedTime);
    }
    #endregion
}
