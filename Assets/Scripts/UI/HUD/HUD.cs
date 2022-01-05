using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("HUD Properties")]
    [SerializeField] private TMP_Text deathCounterText;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject timer;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        GameManager.OnDeathCounterChange += DisplayDeathCounter;
        TimeManager.OnTimeChange += DisplayTime;
    }

    private void Start() => ActivateTimer();

    private void OnDisable()
    {
        GameManager.OnDeathCounterChange -= DisplayDeathCounter;
        TimeManager.OnTimeChange -= DisplayTime;
    }
    #endregion

    #region CLASS METHODS
    public void DisplayDeathCounter(string deathCounter) => deathCounterText.text = deathCounter;

    public void DisplayTime(string time) => timerText.text = time;

    private void ActivateTimer()
    {
        var activateTimer = !GameManager.Instance.IsNormalGameModeActive();

        timer.SetActive(activateTimer);
    }
    #endregion
}