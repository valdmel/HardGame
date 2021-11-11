using UnityEngine;

public class DoorButton : MonoBehaviour
{
    #region VARIABLES
    private const string PRESS_TRIGGER = "Press";
    private const string RELEASE_TRIGGER = "Release";

    #region SERIALIZABLE
    [Header("Door Button Properties")]
    [SerializeField] private GameObject doorBodyObjectToOpen;
    #endregion

    private Animator animator;
    private bool isPressed = false;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => animator = GetComponent<Animator>();

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
    private void PressButton()
    {
        isPressed = true;
        animator.SetTrigger(PRESS_TRIGGER);
    }

    private void ReleaseButton()
    {
        isPressed = false;
        animator.SetTrigger(RELEASE_TRIGGER);
    }
    #endregion
}
