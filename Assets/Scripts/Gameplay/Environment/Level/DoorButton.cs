using UnityEngine;

public class DoorButton : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Door Button Properties")]
    [SerializeField] private GameObject doorBodyObjectToOpen;
    #endregion

    private bool isPressed = false;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => PlayerBody.onPlayerTouchSuperBomb += ReleaseButton;

    private void OnDisable() => PlayerBody.onPlayerTouchSuperBomb -= ReleaseButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithPlayerBody() && !isPressed)
        {
            PressButton();
            doorBodyObjectToOpen.GetComponentInChildren<Door>().Open();
        }
    }
    #endregion

    #region CLASS METHODS
    private void PressButton() => isPressed = true;

    private void ReleaseButton() => isPressed = false;
    #endregion
}
