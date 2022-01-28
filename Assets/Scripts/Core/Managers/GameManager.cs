using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    #region VARIABLES
    public static Action<string> OnDeathCounterChange;
    public static Action OnGamePause;

    public int ActiveGameMode { get; set; }
    public bool IsNormalGameModeActive => ActiveGameMode == (int)GameModeIndex.Normal;
    public int DeathCounter { get; private set; }

    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        PlayerBody.OnPlayerDeath += UpdateDeathCounter;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
        PlayerBody.OnPlayerDeath -= UpdateDeathCounter;
    }
    #endregion

    #region CLASS METHODS
    public void StartLevel()
    {
        if (IsNormalGameModeActive) return;
        
        TimeManager.Instance.InitTime();
    }

    public void PauseGame() => OnGamePause?.Invoke();

    private void UpdateDeathCounter() => OnDeathCounterChange?.Invoke((++DeathCounter).ToString());

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.IsFirst()) return;

        OnDeathCounterChange?.Invoke(DeathCounter.ToString());
    }

    private void OnApplicationQuit() => PlayerPrefs.DeleteAll();
    #endregion
}