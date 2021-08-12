using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("HUD Properties")]
    [SerializeField] private TMP_Text deathCounterText;
    [SerializeField] private TMP_Text timerText;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        GameManager.OnDeathCounterChange += DisplayDeathCounter;
        GameManager.OnTimeChange += DisplayTime;
    }

    private void OnDisable()
    {
        GameManager.OnDeathCounterChange -= DisplayDeathCounter;
        GameManager.OnTimeChange -= DisplayTime;
    }
    #endregion

    #region CLASS METHODS
    public void DisplayDeathCounter(string deathCounter) => deathCounterText.text = deathCounter;

    public void DisplayTime(string time) => timerText.text = time;
    #endregion
}
