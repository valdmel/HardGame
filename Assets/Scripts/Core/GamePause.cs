using UnityEngine;

public class GamePause : MonoBehaviour
{
    #region VARIABLES
    private const float GAME_DEFAULT_TIMESCALE = 1f;

    #region SERIALIZABLE
    [Header("Pause Properties")]
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private AudioClip pauseSFX;
    #endregion

    private AudioSource audioSource;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => audioSource = GetComponent<AudioSource>();

    private void OnEnable() => GameManager.onGamePause += PauseGame;

    private void OnDisable() => GameManager.onGamePause -= PauseGame;
    #endregion

    #region CLASS METHODS
    private void PauseGame()
    {
        Time.timeScale = GAME_DEFAULT_TIMESCALE - Time.timeScale;
        GameManager.Instance.IsGamePaused = !GameManager.Instance.IsGamePaused;

        ActivatePauseMenu();
    }

    private void ActivatePauseMenu()
    {
        audioSource.PlayOneShot(pauseSFX);
        pauseCanvas.SetActive(GameManager.Instance.IsGamePaused);
    }
    #endregion
}
