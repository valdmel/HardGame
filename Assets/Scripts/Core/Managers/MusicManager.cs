using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    #region VARIABLES
    private AudioSource audioSource;
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    protected override void Awake()
    {
        base.Awake();

        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() => GameManager.OnGamePause += HandleAudio;

    private void OnDisable() => GameManager.OnGamePause -= HandleAudio;
    #endregion

    #region CLASS METHODS
    private void HandleAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();

            return;
        }

        audioSource.Play();
    }
    #endregion
}