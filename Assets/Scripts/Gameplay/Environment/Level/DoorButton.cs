using UnityEngine;

public class DoorButton : MonoBehaviour
{
    #region VARIABLES
    private const string PressTrigger = "Press";
    private const string ReleaseTrigger = "Release";

    #region SERIALIZABLE
    [Header("Door Button Properties")]
    [SerializeField] private GameObject doorBodyObjectToOpen;
    #endregion

    private Animator animator;
    private bool isPressed;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => animator = GetComponent<Animator>();

    private void OnEnable() => PlayerBody.OnPlayerTouchSuperBomb += Release;

    private void OnDisable() => PlayerBody.OnPlayerTouchSuperBomb -= Release;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.WasWithPlayerBody() || isPressed) return;
        
        Press();
        doorBodyObjectToOpen.GetComponentInChildren<Door>().Open();
    }
    #endregion

    #region CLASS METHODS
    private void Press()
    {
        isPressed = true;

        animator.SetTrigger(PressTrigger);
    }

    private void Release()
    {
        if (!isPressed) return;
        
        isPressed = false;

        animator.SetTrigger(ReleaseTrigger);
    }
    #endregion
}
