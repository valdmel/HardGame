using UnityEngine;

public class BombRotation : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Rotation Properties")]
    [SerializeField] private GameObject target;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Update() => transform.RotateAround(target.transform.position, Vector3.up, 180 * Time.deltaTime);
    #endregion
}