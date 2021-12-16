using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombResetPosition : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Events Properties")]
    [SerializeField] private UnityEvent onResetPosition;
    #endregion
    
    private Vector3 startingPosition;
    #endregion
    
    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        PlayerBody.onPlayerTouchBomb += ResetPosition;
        PlayerBody.onPlayerTouchSuperBomb += ResetPosition;
    }

    private void Start() => startingPosition = transform.position;

    private void OnDisable()
    {
        PlayerBody.onPlayerTouchBomb -= ResetPosition;
        PlayerBody.onPlayerTouchSuperBomb -= ResetPosition;
    }

    #endregion
    
    #region CLASS METHODS
    private void ResetPosition()
    {
        onResetPosition?.Invoke();
        
        transform.position = startingPosition;
    }
    #endregion
}
