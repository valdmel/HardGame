using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    #region VARIABLES
    public static Action<string> OnDeathCounterChange;
    public static Action OnGamePause;

    private int deathCounter;

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
    public void StartLevel()
    {
        if (IsNormalGameModeActive()) return;
        
        TimeManager.Instance.InitTime();
    }

    public void PauseGame() => OnGamePause?.Invoke();

    public bool IsNormalGameModeActive() => ActiveGameMode == (int)GameModeIndex.Normal;

    private void UpdateDeathCounter() => OnDeathCounterChange?.Invoke((++deathCounter).ToString());

    private void OnSceneLoad(Scene scene, LoadSceneMode mode) => OnDeathCounterChange?.Invoke(deathCounter.ToString());

    private void OnApplicationQuit() => PlayerPrefs.DeleteAll();
    #endregion
}