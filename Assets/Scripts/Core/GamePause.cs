using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamePause : MonoBehaviour
{
    #region VARIABLES
    public static Action OnGamePause;
    public static Action OnGameResume;
    
    #region SERIALIZABLE
    [Header("Pause Properties")]
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject resumeButton;
    #endregion
    
    private AudioSource audioSource;

    private bool IsGamePaused => Time.timeScale < 1f;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => audioSource = GetComponent<AudioSource>();

    private void OnEnable() => GameManager.OnGamePause += PauseGame;

    private void OnDisable() => GameManager.OnGamePause -= PauseGame;
    #endregion

    #region CLASS METHODS
    public void ResumeGame()
    {
        SetTimeScale(1f);
        ActivatePauseMenu();
        OnGameResume?.Invoke();
        EventSystem.current.SetSelectedGameObject(null);
    }
    
    public void SetTimeScale(float timeScale) => Time.timeScale = timeScale;
    
    private void PauseGame()
    {
        SetTimeScale(0f);
        ActivatePauseMenu();
        OnGamePause?.Invoke();
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }

    private void ActivatePauseMenu()
    {
        audioSource.Play();
        pauseCanvas.SetActive(IsGamePaused);
    }
    #endregion
}
