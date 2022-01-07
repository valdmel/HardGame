using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Camera Properties")]
    [SerializeField] private GameObject spawnPoint;
    #endregion
    
    private CinemachineVirtualCamera cinemachineCamera;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Awake()
    {
        var mainCamera = Camera.main.gameObject;
        cinemachineCamera = mainCamera.GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void OnEnable()
    {
        PlayerBody.OnPlayerDeath += ChangeCameraTarget;
        PlayerBody.OnPlayerSpawn += AttachTo;
    }

    private void OnDisable()
    {
        PlayerBody.OnPlayerDeath -= ChangeCameraTarget;
        PlayerBody.OnPlayerSpawn -= AttachTo;
    }

    #endregion

    #region CLASS METHODS
    private void AttachTo(GameObject playerObject)
    {
        var playerBodyObject = playerObject.GetComponentInChildren<PlayerBody>();
        var playerBodyObjectTransform = playerBodyObject.transform;
        cinemachineCamera.Follow = playerBodyObjectTransform;
        cinemachineCamera.LookAt = playerBodyObjectTransform;
    }

    private void ChangeCameraTarget()
    {
        cinemachineCamera.Follow = spawnPoint.transform;
        cinemachineCamera.LookAt = spawnPoint.transform;
    }
    #endregion
}