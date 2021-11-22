using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LocationExit : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Events Properties")]
    [SerializeField] private UnityEvent onLevelFinish;
    #endregion

    private AudioSource audioSource;
    private bool hasLevelFinished = false;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake() => audioSource = GetComponent<AudioSource>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithPlayerBody() && !hasLevelFinished)
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();

            StartCoroutine(FinishLevel(playerController));
        }
    }
    #endregion

    #region CLASS METHODS
    private IEnumerator FinishLevel(PlayerController playerController)
    {
        hasLevelFinished = true;

        audioSource.Play();

        yield return new WaitUntil(() => !audioSource.isPlaying);

        playerController.DisableMovement();
        GameManager.Instance.StopTime();
        onLevelFinish?.Invoke();
    }
    #endregion
}
