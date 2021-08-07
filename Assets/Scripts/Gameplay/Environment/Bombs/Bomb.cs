using UnityEngine;

public class Bomb : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Bomb Properties")]
    [SerializeField] private BombData bombData;
    #endregion

    private float moveSpeed;
    private Vector3 moveDirection;
    private Rigidbody rigidbody;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => rigidbody = GetComponent<Rigidbody>();

    private void Start()
    {
        moveSpeed = bombData.MoveSpeed;
        moveDirection = bombData.MoveDirection;
    }

    private void FixedUpdate() => AddVelocity();

    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithLevelWalls())
        {
            InvertMoveSpeed();
        }
    }
    #endregion

    #region CLASS METHODS
    private void AddVelocity() => transform.Translate(new Vector3(moveDirection.x * moveSpeed, Vector3.zero.y, moveDirection.z * moveSpeed));

    private void InvertMoveSpeed() => moveSpeed = -moveSpeed;
    #endregion
}
