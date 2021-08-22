using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Spawner Properties")]
    [SerializeField] private GameObject playerObjectToSpawn;
    [SerializeField, Min(1)] private float spawnTimeInSeconds = 1f;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => PlayerBody.onPlayerTouchBomb += InitSpawn;

    private void Start() => InitSpawn();

    private void OnDisable() => PlayerBody.onPlayerTouchBomb -= InitSpawn;
    #endregion

    #region CLASS METHODS
    public void InitSpawn() => StartCoroutine(SpawnPlayer());

    public void StartGame() => GameManager.Instance.StartLevel();

    private IEnumerator SpawnPlayer()
    {
        var oldPlayerObject = FindObjectOfType<PlayerBody>()?.transform.parent.gameObject;

        if (oldPlayerObject)
        {
            yield return new WaitForSeconds(spawnTimeInSeconds);
        }

        var playerObject = Instantiate(playerObjectToSpawn);
        var playerBodyObject = playerObject.GetComponentInChildren<PlayerBody>();
        var mainCamera = Camera.main.gameObject;
        var cinemachineCamera = mainCamera.GetComponentInChildren<CinemachineVirtualCamera>();
        cinemachineCamera.Follow = playerBodyObject.transform;
        cinemachineCamera.LookAt = playerBodyObject.transform;

        if (oldPlayerObject)
        {
            Destroy(oldPlayerObject);
        }
    }
    #endregion
}
