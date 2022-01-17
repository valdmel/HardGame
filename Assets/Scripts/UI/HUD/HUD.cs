using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("HUD Properties")]
    [SerializeField] private TMP_Text deathCounterText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private GameObject timer;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        GameManager.OnDeathCounterChange += DisplayDeathCounter;
        TimeManager.OnTimeChange += DisplayTime;
    }

    private void Start()
    {
        ActivateTimer();
        DisplayLevel();
    }

    private void OnDisable()
    {
        GameManager.OnDeathCounterChange -= DisplayDeathCounter;
        TimeManager.OnTimeChange -= DisplayTime;
    }
    #endregion

    #region CLASS METHODS
    private void ActivateTimer()
    {
        var activateTimer = !GameManager.Instance.IsNormalGameModeActive;

        timer.SetActive(activateTimer);
    }
    
    private void DisplayDeathCounter(string deathCounter) => deathCounterText.text = deathCounter;

    private void DisplayTime(string time) => timerText.text = time;
    
    private void DisplayLevel() => levelText.text = $"{SceneManager.GetActiveScene().buildIndex}" +
                                                               $"/{SceneManager.sceneCountInBuildSettings - 1}";
    #endregion
}