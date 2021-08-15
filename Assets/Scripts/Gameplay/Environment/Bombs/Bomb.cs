using UnityEngine;

public class Bomb : MonoBehaviour
{
    #region VARIABLES
    private const int INVERTED_SPEED_MULTIPLIER = -1;

    #region SERIALIZABLE
    [Header("Bomb Properties")]
    [SerializeField] private BombDirection bombDirection;
    [SerializeField] private BombSpeed bombSpeed;
    [SerializeField] private BombBehaviour bombBehaviour;
    [SerializeField] private bool invertSpeed;
    #endregion

    private float moveSpeed;
    private Vector3 moveDirection;

    public BombBehaviour BombBehaviour { get => bombBehaviour; private set => bombBehaviour = value; }
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS

    private void Start()
    {
        moveSpeed = invertSpeed ? bombSpeed.MoveSpeed : bombSpeed.MoveSpeed * INVERTED_SPEED_MULTIPLIER;
        moveDirection = bombDirection.MoveDirection;
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
