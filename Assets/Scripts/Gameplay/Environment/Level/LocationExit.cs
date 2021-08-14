using UnityEngine;
using UnityEngine.Events;

public class LocationExit : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Events Properties")]
    [SerializeField] private UnityEvent onLevelFinish;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithPlayerBody())
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();

            playerController.DisableMovement();
            FinishLevel();
        }
    }
    #endregion

    #region CLASS METHODS
    private void FinishLevel()
    {
        GameManager.Instance.StopTimer();
        onLevelFinish?.Invoke();
    }
    #endregion
}
