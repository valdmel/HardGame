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

    private void OnEnable() => PlayerBody.onPlayerTouchSuperBomb += Release;

    private void OnDisable() => PlayerBody.onPlayerTouchSuperBomb -= Release;

    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithPlayerBody() && !isPressed)
        {
            Press();
            doorBodyObjectToOpen.GetComponentInChildren<Door>().Open();
        }
    }
    #endregion

    #region CLASS METHODS
    private void Press()
    {
        isPressed = true;

        animator.SetTrigger(PRESS_TRIGGER);
    }

    private void Release()
    {
        if (isPressed)
        {
            isPressed = false;
            animator.SetTrigger(RELEASE_TRIGGER);
        }
    }
    #endregion
}
