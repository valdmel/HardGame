using UnityEngine;

public class BombRotation : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Rotation Properties")]
    [SerializeField] private GameObject target;
    [SerializeField, Range(1, 180)] private int moveSpeed;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Update() => Rotate();
    #endregion

    #region CLASS METHODS
    private void Rotate() => transform.RotateAround(target.transform.position, Vector3.up, moveSpeed * Time.deltaTime);
    #endregion
}