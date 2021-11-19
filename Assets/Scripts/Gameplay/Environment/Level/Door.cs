using UnityEngine;

public class Door : MonoBehaviour
{
    #region VARIABLES
    private const string OPEN_TRIGGER = "Open";
    private const string CLOSE_TRIGGER = "Close";

    private Animator animator;
    private bool isOpened = false;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => animator = GetComponent<Animator>();

    private void OnEnable() => PlayerBody.onPlayerTouchSuperBomb += Close;

    private void OnDisable() => PlayerBody.onPlayerTouchSuperBomb -= Close;
    #endregion

    #region CLASS METHODS
    public void Open()
    {
        isOpened = true;

        animator.SetTrigger(OPEN_TRIGGER);
    }

    public void Close()
    {
        if (isOpened)
        {
            isOpened = false;

            animator.SetTrigger(CLOSE_TRIGGER);
        }
    }
    #endregion
}