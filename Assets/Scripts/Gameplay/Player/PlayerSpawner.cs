using Cinemachine;
using System;
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
    private void OnEnable() => PlayerBody.OnPlayerDeath += InitSpawn;

    private void Start() => InitSpawn();

    private void OnDisable() => PlayerBody.OnPlayerDeath -= InitSpawn;
    #endregion

    #region CLASS METHODS
    public void StartGame() => GameManager.Instance.StartLevel();

    private IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(spawnTimeInSeconds);

        Instantiate(playerObjectToSpawn, transform.position, Quaternion.identity);
    }
    
    private void InitSpawn() => StartCoroutine(SpawnPlayer());
    #endregion
}
