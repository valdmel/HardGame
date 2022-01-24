using UnityEngine;

public class BombMovement : Bomb, IMovable
{
    #region VARIABLES
    private const float MinDistance = 0.1f;

    #region SERIALIZABLE
    [Header("Waypoint Properties")]
    [SerializeField] private Transform[] waypoints;
    #endregion

    private int currentWaypointIndex;
    private Vector3 targetWaypoint;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start() => Init();

    private void Update()
    {
        if (waypoints.Length == 0) return;

        Move();
    }
    #endregion

    #region CLASS METHODS
    protected override void Init()
    {
        base.Init();

        if (waypoints.Length == 0) return;

        targetWaypoint = waypoints[currentWaypointIndex].transform.position;
    }

    public void Move()
    {
        var distanceFromWaypointToCurrentPosition = Vector3.Distance(targetWaypoint, transform.position);
        var hasReachedWaypoint = distanceFromWaypointToCurrentPosition < MinDistance;

        if (hasReachedWaypoint)
        {
            SetNextWaypoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, moveSpeed * Time.deltaTime);
    }

    private void SetNextWaypoint()
    {
        var hasReachedLastWaypoint = ++currentWaypointIndex >= waypoints.Length;
        currentWaypointIndex = hasReachedLastWaypoint ? 0 : currentWaypointIndex;
        targetWaypoint = waypoints[currentWaypointIndex].transform.position;
    }
    #endregion
}