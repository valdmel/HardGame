using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LocationExit : MonoBehaviour
{
    #region VARIABLES
    private const int WaitTime = 1;

    #region SERIALIZABLE
    [Header("Events Properties")]
    [SerializeField] private UnityEvent onLevelFinish;
    #endregion

    private bool hasLevelFinished;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (!other.WasWithPlayerBody() || hasLevelFinished) return;
        
        var playerMovement = other.gameObject.GetComponent<ICanMove>();

        StartCoroutine(FinishLevel(playerMovement));
    }
    #endregion

    #region CLASS METHODS
    private IEnumerator FinishLevel(ICanMove playerMovement)
    {
        hasLevelFinished = true;

        yield return new WaitForSeconds(WaitTime);

        playerMovement.DisableMovement();

        if (!GameManager.Instance.IsNormalGameModeActive)
        {
            TimeManager.Instance.StopTime();
        }
        
        onLevelFinish?.Invoke();
    }
    #endregion
}
