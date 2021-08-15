using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    private const string PLAYER_ACTION_MAP = "Player";
    private const string PAUSE_ACTION_MAP = "Pause";

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

    private void FixedUpdate() => AddVelocity();
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

        if (canPauseGame)
        {
            GameManager.Instance.PauseGame();

            switch (GameManager.Instance.IsGamePaused)
            {
                case true:
                    playerInput.SwitchCurrentActionMap(PAUSE_ACTION_MAP);
                    break;

                case false:
                    playerInput.SwitchCurrentActionMap(PLAYER_ACTION_MAP);
                    break;
            }
        }
    }

    public void DisableMovement() => playerInput.enabled = false;

    private void AddVelocity() => characterController.SimpleMove(movementDirection);
    #endregion
}