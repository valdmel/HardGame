using System;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    #region VARIABLES
    public static Action OnGamePause;
    public static Action OnGameResume;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => GameManager.OnGamePause += PauseGame;

    private void OnDisable() => GameManager.OnGamePause -= PauseGame;
    #endregion

    #region CLASS METHODS
    public void ResumeGame()
    {
        SetTimeScale(1f);
        OnGameResume?.Invoke();
    }
    
    public void SetTimeScale(float timeScale) => Time.timeScale = timeScale;
    
    private void PauseGame()
    {
        SetTimeScale(0f);
        OnGamePause?.Invoke();
    }
    #endregion
}