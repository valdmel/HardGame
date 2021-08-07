using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBody : MonoBehaviour
{
    #region VARIABLES
    private const string BOMB_TAG = "Bomb";

    public static Action OnPlayerDeath;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnTriggerEnter(Collider other)
    {
        var isTouchingBomb = other.CompareTag(BOMB_TAG);

        if (isTouchingBomb)
        {
            Kill();
        }
    }
    #endregion

    #region CLASS METHODS
    private void Kill()
    {
        OnPlayerDeath?.Invoke();
        Destroy(gameObject.transform.parent.gameObject);
    }
    #endregion
}
