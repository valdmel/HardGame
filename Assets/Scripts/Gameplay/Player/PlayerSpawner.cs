using Cinemachine;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Spawner Properties")]
    [SerializeField] private GameObject playerObjectToSpawn;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start() => SpawnPlayer();
    #endregion

    #region CLASS METHODS
    private void SpawnPlayer()
    {
        var playerObject = Instantiate(playerObjectToSpawn);
        var playerBodyObject = playerObject.GetComponentInChildren<PlayerBody>();
        var mainCamera = Camera.main.gameObject;
        var cinemachineCamera = mainCamera.GetComponentInChildren<CinemachineVirtualCamera>();
        cinemachineCamera.Follow = playerBodyObject.transform;
        cinemachineCamera.LookAt = playerBodyObject.transform;
    }
    #endregion
}
