using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    #region VARIABLES
    private const string LEVEL_WALLS_TAG = "Level";

    #region SERIALIZABLE
    [Header("Spawner Properties")]
    [SerializeField] private GameObject playerObjectToSpawn;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => PlayerBody.OnPlayerDeath += SpawnPlayer;

    private void Start()
    {
        SpawnPlayer();
    }

    private void OnDisable() => PlayerBody.OnPlayerDeath -= SpawnPlayer;
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
