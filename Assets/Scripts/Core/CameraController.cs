using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region VARIABLES
    private CinemachineVirtualCamera cinemachineCamera;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake()
    {
        var mainCamera = Camera.main.gameObject;
        cinemachineCamera = mainCamera.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void OnEnable() => PlayerSpawner.onPlayerSpawn += AttachTo;

    private void OnDisable() => PlayerSpawner.onPlayerSpawn -= AttachTo;
    #endregion

    #region CLASS METHODS
    private void AttachTo(GameObject playerObject)
    {
        var playerBodyObject = playerObject.GetComponentInChildren<PlayerBody>();
        cinemachineCamera.Follow = playerBodyObject.transform;
        cinemachineCamera.LookAt = playerBodyObject.transform;
    }
    #endregion
}
