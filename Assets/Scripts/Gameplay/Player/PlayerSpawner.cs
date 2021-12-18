using Cinemachine;
using System;
using System.Collections;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    #region VARIABLES
    public static Action<GameObject> OnPlayerSpawn;

    #region SERIALIZABLE
    [Header("Spawner Properties")]
    [SerializeField] private GameObject playerObjectToSpawn;
    [SerializeField, Min(1)] private float spawnTimeInSeconds = 1f;
    #endregion

    private CinemachineVirtualCamera cinemachineCamera;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        PlayerBody.OnPlayerTouchBomb += InitSpawn;
        PlayerBody.OnPlayerTouchSuperBomb += InitSpawn;
    }

    private void Start() => InitSpawn();

    private void OnDisable()
    {
        PlayerBody.OnPlayerTouchBomb -= InitSpawn;
        PlayerBody.OnPlayerTouchSuperBomb -= InitSpawn;
    }
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

        var playerObject = Instantiate(playerObjectToSpawn, transform.position, Quaternion.identity);

        OnPlayerSpawn?.Invoke(playerObject);

        if (oldPlayerObject)
        {
            Destroy(oldPlayerObject);
        }
    }
    #endregion
}
