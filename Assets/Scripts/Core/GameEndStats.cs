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
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start()
    {
        timerText.gameObject.SetActive(!GameManager.Instance.IsNormalGameModeActive);
        ShowGameStats();
    }

    #endregion
    
    #region CLASS METHODS
    private void ShowGameStats()
    {
        deathCounterText.text = DeathText + GameManager.Instance.DeathCounter;

        if (GameManager.Instance.IsNormalGameModeActive) return;

        timerText.text = TimeText + TimeManager.Instance.ElapsedTime;
    }
    #endregion
}
