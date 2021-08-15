using System;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    #region VARIABLES
    public static Action onPlayerTouchBomb;
    public static Action onPlayerTouchSuperBomb;
    public static Action onPlayerDeath;

    #region SERIALIZABLE
    [Header("Body Properties")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathSFX;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => GameManager.onTimeMax += Kill;

    private void Start() => GameManager.Instance.InitTime();

    private void OnDisable() => GameManager.onTimeMax -= Kill;

    private void OnTriggerEnter(Collider other)
    {
        var bomb = other.GetComponent<Bomb>();

        if (bomb)
        {
            bomb.BombBehaviour.Execute(gameObject);
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
