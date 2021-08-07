using System;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    #region VARIABLES
    private const string BOMB_TAG = "Bomb";
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BOMB_TAG))
        {
            Kill();
        }
            
    }
    #endregion

    #region CLASS METHODS
    private void Kill()
    {
        throw new NotImplementedException();
    }
    #endregion
}
