using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    private const string PlayerActionMap = "Player";
    private const string PauseActionMap = "Pause";

    #region SERIALIZABLE
    [Header("Player Properties")]
    [SerializeField] private float moveSpeed = 5f;
    #endregion

    private CharacterController characterController;
    private PlayerInput playerInput;
    private Vector3 movementDirection;
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

    private void FixedUpdate() => AddVelocity();

    private void OnDisable()
    {
        GamePause.OnGameResume -= EnableMovement;
        GamePause.OnGamePause -= DisableMovement;
    }

    #endregion

    #region CLASS METHODS
    public void OnMove(InputAction.CallbackContext inputContext)
    {
        var inputMovement = inputContext.ReadValue<Vector2>();
        movementDirection = new Vector3(inputMovement.x, 0, inputMovement.y) * moveSpeed;
    }

    public void OnPause(InputAction.CallbackContext inputContext)
    {
        var canPauseGame = inputContext.performed;

        if (!canPauseGame) return;

        GameManager.Instance.PauseGame();
    }

    private void EnableMovement() => playerInput.enabled = true;
    
    public void DisableMovement() => playerInput.enabled = false;

    private void AddVelocity() => characterController.SimpleMove(movementDirection);
    #endregion
}