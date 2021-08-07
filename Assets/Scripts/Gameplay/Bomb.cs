using UnityEngine;

public class Bomb : MonoBehaviour
{
    #region VARIABLES
    private const string LEVEL_WALLS_TAG = "Level";

    #region SERIALIZABLE
    [Header("Bomb Properties")]
    [SerializeField] private float moveSpeed = 1f;
    #endregion

    private Rigidbody rigidbody;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate() => AddVelocity();

    private void OnTriggerEnter(Collider other)
    {
        var isTouchingLevelWalls = other.CompareTag(LEVEL_WALLS_TAG);

        if (isTouchingLevelWalls)
        {
            InvertMoveSpeed();
        }
    }
    #endregion

    #region CLASS METHODS
    public void AddVelocity() => transform.Translate(new Vector3(moveSpeed, Vector3.zero.y, Vector3.zero.z));

    private void InvertMoveSpeed() => moveSpeed = -moveSpeed;
    #endregion
}
