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
    private Vector3 targetWaypoint;
    private float moveSpeed;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start()
    {
        moveSpeed = bombSpeed.MoveSpeed;

        if (waypoints.Length == 0) return;

        targetWaypoint = waypoints[currentWaypointIndex].transform.position;
    }

    private void FixedUpdate()
    {
        if (waypoints.Length == 0) return;

        Move();
    }
    #endregion

    #region CLASS METHODS
    private void Move()
    {
        var distanceFromWaypointToCurrentPosition = Vector3.Distance(targetWaypoint, transform.position);
        var hasReachedWaypoint = distanceFromWaypointToCurrentPosition < MIN_DISTANCE;

        if (hasReachedWaypoint)
        {
            SetNextWaypoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, moveSpeed * Time.fixedDeltaTime);
    }

    private void SetNextWaypoint()
    {
        var hasReachedLastWaypoint = ++currentWaypointIndex >= waypoints.Length;
        currentWaypointIndex = hasReachedLastWaypoint ? 0 : currentWaypointIndex;
        targetWaypoint = waypoints[currentWaypointIndex].transform.position;
    }
    #endregion
}