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

    private bool isGamePaused;
    private AudioSource audioSource;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => audioSource = GetComponent<AudioSource>();

    private void OnEnable() => GameManager.OnGamePause += PauseGame;

    private void OnDisable() => GameManager.OnGamePause -= PauseGame;
    #endregion

    #region CLASS METHODS
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;

        ActivatePauseMenu();
        OnGameResume?.Invoke();
        EventSystem.current.SetSelectedGameObject(null);
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;

        ActivatePauseMenu();
        OnGamePause?.Invoke();
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }

    private void ActivatePauseMenu()
    {
        audioSource.Play();
        pauseCanvas.SetActive(isGamePaused);
    }
    #endregion
}
