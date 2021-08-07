using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBody : MonoBehaviour
{
    #region VARIABLES
    public static Action OnPlayerDeath;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithBomb())
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
