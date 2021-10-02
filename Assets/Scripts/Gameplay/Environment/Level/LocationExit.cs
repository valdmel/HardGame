using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LocationExit : MonoBehaviour
{
    #region VARIABLES
    private const float WAIT_TIME = 1f;

    private bool hasLevelFinished = false;

    #region SERIALIZABLE
    [Header("Events Properties")]
    [SerializeField] private UnityEvent onLevelFinish;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithPlayerBody() && !hasLevelFinished)
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();
            hasLevelFinished = true;

            StartCoroutine(FinishLevel(playerController));
        }
    }
    #endregion

    #region CLASS METHODS
    private IEnumerator FinishLevel(PlayerController playerController)
    {
        yield return new WaitForSeconds(WAIT_TIME);

        playerController.DisableMovement();
        GameManager.Instance.StopTime();
        onLevelFinish?.Invoke();
    }
    #endregion
}
