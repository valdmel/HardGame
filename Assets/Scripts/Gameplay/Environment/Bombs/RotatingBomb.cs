using UnityEngine;

public class RotatingBomb : Bomb
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Rotation Properties")]
    [SerializeField] private GameObject target;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Update() => Rotate();
    #endregion

    #region CLASS METHODS
    private void Rotate() => transform.RotateAround(target.transform.position, Vector3.up, moveSpeed * Time.deltaTime);
    #endregion
}