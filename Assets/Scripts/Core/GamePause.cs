using UnityEngine;

public class GamePause : MonoBehaviour
{
    #region VARIABLES
    private const float GameDefaultTimescale = 1f;

    #region SERIALIZABLE
    [Header("Pause Properties")]
    [SerializeField] private GameObject pauseCanvas;
    #endregion

    private AudioSource audioSource;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => audioSource = GetComponent<AudioSource>();

    private void OnEnable() => GameManager.OnGamePause += PauseGame;

    private void OnDisable() => GameManager.OnGamePause -= PauseGame;
    #endregion

    #region CLASS METHODS
    private void PauseGame()
    {
        Time.timeScale = GameDefaultTimescale - Time.timeScale;
        GameManager.Instance.IsGamePaused = !GameManager.Instance.IsGamePaused;

        ActivatePauseMenu();
    }

    private void ActivatePauseMenu()
    {
        audioSource.Play();
        pauseCanvas.SetActive(GameManager.Instance.IsGamePaused);
    }
    #endregion
}
