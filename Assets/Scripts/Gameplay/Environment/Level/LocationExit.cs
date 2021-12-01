using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LocationExit : MonoBehaviour
{
    #region VARIABLES
    private const int WAIT_TIME = 1;

    #region SERIALIZABLE
    [Header("Events Properties")]
    [SerializeField] private UnityEvent onLevelFinish;
    #endregion

    private bool hasLevelFinished = false;
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

        yield return new WaitForSeconds(WAIT_TIME);

        playerController.DisableMovement();
        //GameManager.Instance.StopTime();
        onLevelFinish?.Invoke();
    }
    #endregion
}
