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
        if (other.WasWithPlayerBody() && !hasLevelFinished)
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();

            StartCoroutine(FinishLevel(playerController));
        }
    }
    #endregion

    #region CLASS METHODS
    private IEnumerator FinishLevel(PlayerController playerController)
    {
        hasLevelFinished = true;

        yield return new WaitForSeconds(WaitTime);

        playerController.DisableMovement();
        GameManager.Instance.StopTime();
        onLevelFinish?.Invoke();
    }
    #endregion
}
