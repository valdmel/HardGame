using UnityEngine;

public class Door : MonoBehaviour
{
    #region VARIABLES
    private const string OPEN_TRIGGER = "Open";
    private const string CLOSE_TRIGGER = "Close";

    private Animator animator;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => animator = GetComponent<Animator>();

    private void OnEnable() => PlayerBody.onPlayerTouchSuperBomb += Close;

    private void OnDisable() => PlayerBody.onPlayerTouchSuperBomb -= Close;
    #endregion

    #region CLASS METHODS
    public void Open() => animator.SetTrigger(OPEN_TRIGGER);

    public void Close() => animator.SetTrigger(CLOSE_TRIGGER);
    #endregion
}