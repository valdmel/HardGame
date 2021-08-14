using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    #region VARIABLES
    private const float MIN_DISTANCE = 0.1f;

    #region SERIALIZABLE
    [Header("Door Properties")]
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField, Min(0)] private float doorOpeningSpeed = 0.1f;
    #endregion

    private bool isOpened = false;
    private Coroutine doorOpenCoroutine;
    #endregion

    #region CLASS METHODS
    public void Open()
    {
        isOpened = true;
        doorOpenCoroutine = StartCoroutine(SlideEffect(endPosition.position));
    }

    public void Close()
    {
        if (isOpened)
        {
            isOpened = false;
            doorOpenCoroutine = StartCoroutine(SlideEffect(startPosition.position));
        }
    }

    private IEnumerator SlideEffect(Vector3 toPosition)
    {
        do
        {
            transform.position = Vector3.Lerp(transform.position, toPosition, doorOpeningSpeed);

            yield return null;

        } while (Vector3.Distance(transform.position, toPosition) > MIN_DISTANCE);

        StopCoroutine(doorOpenCoroutine);
    }
    #endregion
}
