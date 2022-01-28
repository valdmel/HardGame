using TMPro;
using UnityEngine;

public class GameEndStats : MonoBehaviour
{
    #region VARIABLES
    private const string DeathText = "Deaths: ";
    private const string TimeText = "Time: ";

    #region SERIALIZABLE
    [Header("Text Properties")]
    [SerializeField] private TMP_Text deathCounterText;
    [SerializeField] private TMP_Text timerText;
    #endregion
    
    private bool ActivateTimerText => !GameManager.Instance.IsNormalGameModeActive;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start()
    {
        timerText.gameObject.SetActive(ActivateTimerText);
        ShowGameStats();
    }

    #endregion
    
    #region CLASS METHODS
    private void ShowGameStats()
    {
        deathCounterText.text = DeathText + GameManager.Instance.DeathCounter;

        if (!timerText.enabled) return;

        timerText.text = TimeText + TimeManager.Instance.ElapsedTime;
    }
    #endregion
}
