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

    private void OnEnable()
    {
        GamePause.OnGamePause += MuteAudio;
        GamePause.OnGameResume += ResumeAudio;
    }

    private void OnDisable()
    {
        GamePause.OnGamePause -= MuteAudio;
        GamePause.OnGameResume -= ResumeAudio;
    }

    #endregion

    #region CLASS METHODS
    private void MuteAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }
    
    private void ResumeAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    #endregion
}