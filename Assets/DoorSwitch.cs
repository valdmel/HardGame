using System.Collections;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    #region VARIABLES
    private const float MIN_DISTANCE = 0f;

    #region SERIALIZABLE
    [Header("Door Switch Properties")]
    [SerializeField] private GameObject doorBodyObjectToOpen;
    [SerializeField] private Transform doorBodyObjectToOpenEndPosition;
    [SerializeField, Min(0)] private float doorOpeningSpeed = 0.1f;
    #endregion

    private Vector3 doorBodyStartPosition;
    private bool isDoorOpening = false;
    private Coroutine doorOpenCoroutine;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start() => doorBodyStartPosition = doorBodyObjectToOpen.transform.position;

    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithPlayerBody() && !isDoorOpening)
        {
            doorOpenCoroutine = StartCoroutine(OpenDoor());
        }
    }
    #endregion

    #region CLASS METHODS
    private IEnumerator OpenDoor()
    {
        isDoorOpening = true;
        var distanceFromDoorToEndingPosition = Vector3.Distance(doorBodyStartPosition, doorBodyObjectToOpenEndPosition.position);

        do
        {
            doorBodyObjectToOpen.transform.position = Vector3.Lerp(doorBodyObjectToOpen.transform.position, doorBodyObjectToOpenEndPosition.position, doorOpeningSpeed);
            distanceFromDoorToEndingPosition = Vector3.Distance(doorBodyObjectToOpen.transform.position, doorBodyObjectToOpenEndPosition.position);

            yield return null;
        } while (distanceFromDoorToEndingPosition > MIN_DISTANCE);

        StopCoroutine(doorOpenCoroutine);
    }
    #endregion
}
