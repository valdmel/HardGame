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

    private void OnEnable() => GameManager.onGamePause += HandleAudio;

    private void OnDisable() => GameManager.onGamePause -= HandleAudio;
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