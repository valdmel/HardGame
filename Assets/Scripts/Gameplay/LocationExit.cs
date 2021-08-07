using UnityEngine;
using UnityEngine.Events;

public class LocationExit : MonoBehaviour
{
    #region VARIABLES
    private const string PLAYER_BODY_TAG = "PlayerBody";

    #region SERIALIZABLE
    [Header("Events Properties")]
    [SerializeField] private UnityEvent onLevelFinish;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnTriggerEnter(Collider other)
    {
        var isTouchingPlayerBody = other.CompareTag(PLAYER_BODY_TAG);

        if (isTouchingPlayerBody)
        {
            var playerBodyObject = other.gameObject.GetComponent<PlayerBody>();

            playerBodyObject.DisableMovement();
            FinishLevel();
        }
    }
    #endregion

    #region CLASS METHODS
    private void FinishLevel()
    {
        onLevelFinish?.Invoke();
    }
    #endregion
}
