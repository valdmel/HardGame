using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region VARIABLES
    private PlayerMovement playerMovement;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => playerMovement = GetComponent<PlayerMovement>();
    #endregion

    #region CLASS METHODS
    public void OnMove(InputAction.CallbackContext inputContext)
    {
        var inputMovement = inputContext.ReadValue<Vector2>();

        playerMovement.CalculateMovementDirection(inputMovement);
    }

    public void OnPause(InputAction.CallbackContext inputContext)
    {
        var canPauseGame = inputContext.performed;

        if (!canPauseGame) return;

        GameManager.Instance.PauseGame();
    }
    #endregion
}