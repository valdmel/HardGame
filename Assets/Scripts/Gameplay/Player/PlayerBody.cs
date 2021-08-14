using System;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    #region VARIABLES
    public static Action onPlayerDeath;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start() => GameManager.Instance.InitTimer();

    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithBomb())
        {
            Kill();
        }
        else if (other.WasWithSuperBomb())
        {
            Kill();
        }
    }
    #endregion

    #region CLASS METHODS
    private void Kill()
    {
        onPlayerDeath?.Invoke();
        transform.parent.gameObject.SetActive(false);
    }
    #endregion
}
