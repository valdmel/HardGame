using System;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    #region VARIABLES
    public static Action onPlayerDeath;

    #region SERIALIZABLE
    [Header("Body Properties")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathSFX;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => GameManager.OnTimeMax += Kill;

    private void Start() => GameManager.Instance.InitTime();

    private void OnDisable() => GameManager.OnTimeMax -= Kill;

    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithBomb())
        {
            Kill();
        }
        else if (other.WasWithSuperBomb())
        {
            Kill();
        }
    }
    #endregion

    #region CLASS METHODS
    public void Kill()
    {
        onPlayerDeath?.Invoke();
        transform.parent.gameObject.SetActive(false);
    }
    #endregion
}
