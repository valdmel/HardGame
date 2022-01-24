using UnityEngine;

public class BombRotation : Bomb, IMovable
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Rotation Properties")]
    [SerializeField] private GameObject rotationTarget;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void FixedUpdate() => Move();
    #endregion

    #region CLASS METHODS
    public void Move() => transform.RotateAround(rotationTarget.transform.position, Vector3.up, moveSpeed * Time.fixedDeltaTime);
    #endregion
}