using System;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    #region VARIABLES
    public static Action OnPlayerDeath;
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
            GameManager.Instance.LoadPreviousScene();
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
