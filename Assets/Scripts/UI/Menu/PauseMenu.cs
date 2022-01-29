using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Menu Properties")]
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject resumeButton;
    #endregion
    
    private AudioSource audioSource;
    #endregion
    
    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => audioSource = GetComponent<AudioSource>();
    
    private void OnEnable()
    {
        GamePause.OnGamePause += Activate;
        GamePause.OnGameResume += Deactivate;
    }

    private void OnDisable()
    {
        GamePause.OnGamePause -= Activate;
        GamePause.OnGameResume -= Deactivate;
    }

    #endregion
    
    #region CLASS METHODS
    private void Activate()
    {
        audioSource.Play();
        pauseCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(resumeButton);
    }
    
    private void Deactivate()
    {
        audioSource.Play();
        pauseCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
    #endregion
}