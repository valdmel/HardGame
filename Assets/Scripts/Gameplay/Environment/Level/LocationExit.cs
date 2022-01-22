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

        FinishLevel(other);
    }
    #endregion

    #region CLASS METHODS
    private void FinishLevel(Collider other)
    {
        var playerMovement = other.gameObject.GetComponent<IMovement>();

        DisablePlayerMovement(playerMovement);
        StartCoroutine(FinishLevel());
    }
    
    private IEnumerator FinishLevel()
    {
        hasLevelFinished = true;

        yield return new WaitForSeconds(WaitTime);
        
        StopTime();
        onLevelFinish?.Invoke();
    }

    private void DisablePlayerMovement(IMovement playerMovement) => playerMovement.DisableMovement();

    private void StopTime()
    {
        if (GameManager.Instance.IsNormalGameModeActive) return;
        
        TimeManager.Instance.StopTime();
    }
    #endregion
}
