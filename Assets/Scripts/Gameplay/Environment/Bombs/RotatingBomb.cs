using UnityEngine;

public class RotatingBomb : Bomb
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Rotation Properties")]
    [SerializeField] private GameObject rotationTarget;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Update() => Rotate();
    #endregion

    #region CLASS METHODS
    private void Rotate() => transform.RotateAround(rotationTarget.transform.position, Vector3.up, moveSpeed * Time.deltaTime);
    #endregion
}