using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    #region VARIABLES
    private const int unplayableLevelsCount = 2;

    #region SERIALIZABLE
    [Header("HUD Properties")]
    [SerializeField] private TMP_Text deathCounterText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private GameObject timer;
    #endregion

    private int CurrentSceneIndex => SceneManager.GetActiveScene().buildIndex;
    private int PlayableLevelsCount => SceneManager.sceneCountInBuildSettings - unplayableLevelsCount;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        GameManager.OnDeathCounterChange += DisplayDeathCounter;
        TimeManager.OnElapsedTime += DisplayTime;
    }

    private void Start()
    {
        ActivateTimer();
        DisplayLevel();
    }

    private void OnDisable()
    {
        GameManager.OnDeathCounterChange -= DisplayDeathCounter;
        TimeManager.OnElapsedTime -= DisplayTime;
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
    
    private void DisplayLevel() => levelText.text = $"{CurrentSceneIndex}" + $"/{PlayableLevelsCount}";
    #endregion
}