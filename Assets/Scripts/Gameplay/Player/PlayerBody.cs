using System;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    #region VARIABLES
    public static Action onPlayerTouchBomb;
    public static Action onPlayerTouchSuperBomb;

    #region SERIALIZABLE
    [Header("Audio Properties")]
    [SerializeField] private GameObject detacheableAudioSource;
    [SerializeField] private AudioClip deathSFX;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => GameManager.onTimeMax += Kill;

    private void OnDisable() => GameManager.onTimeMax -= Kill;

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

        audioSource.GetComponent<DetachableAudioSource>().PlayOneShot(deathSFX);
        transform.parent.gameObject.SetActive(false);
    }
    #endregion
}