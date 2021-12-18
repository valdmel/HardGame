using UnityEngine;

public class Door : MonoBehaviour
{
    #region VARIABLES
    private const string OpenTrigger = "Open";
    private const string CloseTrigger = "Close";

    private Animator animator;
    private bool isOpened;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => animator = GetComponent<Animator>();

    private void OnEnable() => PlayerBody.OnPlayerTouchSuperBomb += Close;

    private void OnDisable() => PlayerBody.OnPlayerTouchSuperBomb -= Close;
    #endregion

    #region CLASS METHODS
    public void Open()
    {
        isOpened = true;

        animator.SetTrigger(OpenTrigger);
    }

    public void Close()
    {
        if (!isOpened) return;
        
        isOpened = false;

        animator.SetTrigger(CloseTrigger);
    }
    #endregion
}