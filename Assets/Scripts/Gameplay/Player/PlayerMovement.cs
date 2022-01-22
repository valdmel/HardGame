using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IMovable, IMovement
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Movement Properties")]
    [SerializeField] private PlayerSpeed playerSpeed;
    #endregion
    
    private CharacterController characterController;
    private PlayerInput playerInput;
    private Vector3 movementDirection;
    
    private int moveSpeed => playerSpeed.MoveSpeed;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        GamePause.OnGameResume += EnableMovement;
        GamePause.OnGamePause += DisableMovement;
    }

    private void FixedUpdate() => Move();

    private void OnDisable()
    {
        GamePause.OnGameResume -= EnableMovement;
        GamePause.OnGamePause -= DisableMovement;
    }
    #endregion
    
    #region CLASS METHODS
    public void Move() => characterController.SimpleMove(movementDirection * moveSpeed);
    
    public void EnableMovement() => playerInput.enabled = true;
    
    public void DisableMovement() => playerInput.enabled = false;
    
    public void CalculateMovementDirection(Vector3 inputMovement) => movementDirection = new Vector3(inputMovement.x, 
        Vector3.zero.y, inputMovement.y);
    #endregion
}