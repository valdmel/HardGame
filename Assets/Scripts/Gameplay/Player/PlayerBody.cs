using System;
using UnityEngine;

public class PlayerBody : MonoBehaviour, IKillable
{
    #region VARIABLES
    public static Action<GameObject> OnPlayerSpawn;
    public static Action OnPlayerDeath;
    public static Action OnPlayerTouchBomb;
    public static Action OnPlayerTouchSuperBomb;

    #region SERIALIZABLE
    [Header("Audio Properties")]
    [SerializeField] private GameObject detacheableAudioSource;
    [SerializeField] private AudioClip deathSfx;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start() => OnPlayerSpawn?.Invoke(transform.parent.gameObject);

    private void OnTriggerEnter(Collider other)
    {
        var bomb = other.GetComponent<BombBehaviour>();

        if (bomb)
        {
            bomb.ApplyTypeBehaviourTo(gameObject);
        }
    }
    #endregion

    #region CLASS METHODS
    public void Kill()
    {
        var audioSource = Instantiate(detacheableAudioSource);

        audioSource.GetComponent<DetachableAudioSource>().PlayOneShot(deathSfx);
        Destroy(transform.parent.gameObject);
    }

    private void OnDestroy() => OnPlayerDeath?.Invoke();
    #endregion
}