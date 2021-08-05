using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region SERIALIZABLE
    [Header("Player Properties")]
    [SerializeField] private float moveSpeed = 5f;
    #endregion

    private CharacterController characterController;
    private PlayerInput playerInput;
    private Vector3 movementDirection;

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate() => AddVelocity();
    #endregion

    #region CLASS METHODS
    public void OnMove(InputAction.CallbackContext inputContext)
    {
        var inputMovement = inputContext.ReadValue<Vector2>();
        movementDirection = new Vector3(inputMovement.x, 0, inputMovement.y) * moveSpeed;
    }

    public void AddVelocity() => characterController.SimpleMove(movementDirection);
    #endregion
}