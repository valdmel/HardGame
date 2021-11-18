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
    private void Start()
    {
        transform.position = waypoints[0].transform.position;
        moveSpeed = bombSpeed.MoveSpeed;
    }

    private void FixedUpdate() => AddVelocity();
    #endregion

    #region CLASS METHODS
    private void AddVelocity()
    {
        var distanceFromWaypointToCurrentPosition = Vector3.Distance(waypoints[currentWaypointIndex].transform.position, transform.position);

        if (distanceFromWaypointToCurrentPosition < 0.1)
        {
            if (++currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * moveSpeed);
    }
    #endregion
}