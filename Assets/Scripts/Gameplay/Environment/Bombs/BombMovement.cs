using UnityEngine;

public abstract class BombMovement : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [SerializeField, Range(-180, 180)] private int bombSpeed;
    #endregion

    protected int moveSpeed;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start() => Init();

    private void OnValidate() => Init();
    #endregion

    #region CLASS METHODS
    protected virtual void Init() => moveSpeed = bombSpeed;
    #endregion
}
