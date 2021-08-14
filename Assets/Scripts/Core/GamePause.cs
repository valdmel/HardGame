using UnityEngine;

public class GamePause : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Pause Properties")]
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private AudioClip pauseSFX;
    #endregion

    private AudioSource audioSource;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => audioSource = GetComponent<AudioSource>();

    private void OnEnable() => GameManager.OnGamePause += ActivatePauseMenu;

    private void OnDisable() => GameManager.OnGamePause -= ActivatePauseMenu;
    #endregion

    #region CLASS METHODS
    private void ActivatePauseMenu()
    {
        audioSource.PlayOneShot(pauseSFX);
        pauseCanvas.SetActive(GameManager.Instance.IsGamePaused);
    }
    #endregion
}
