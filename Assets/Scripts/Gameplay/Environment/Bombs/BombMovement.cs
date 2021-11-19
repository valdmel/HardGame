using UnityEngine;

public class BombMovement : MonoBehaviour
{
    #region VARIABLES
    private const float MIN_DISTANCE = 0.1f;

    #region SERIALIZABLE
     [Header("Movement Properties")]
     [SerializeField] private BombSpeed bombSpeed;
     [SerializeField] private Transform[] waypoints;
     #endregion

     private int currentWaypointIndex = 0;
     private float moveSpeed;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start() => moveSpeed = bombSpeed.MoveSpeed;

    private void Update()
    {
        if (waypoints.Length == 0) return;

        Move();
    }
    #endregion

    #region CLASS METHODS
    private void Move()
    {
        var distanceFromWaypointToCurrentPosition = Vector3.Distance(waypoints[currentWaypointIndex].transform.position, transform.position);

        if (distanceFromWaypointToCurrentPosition < MIN_DISTANCE)
        {
            if (++currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, moveSpeed * Time.deltaTime);
    }
    #endregion
}