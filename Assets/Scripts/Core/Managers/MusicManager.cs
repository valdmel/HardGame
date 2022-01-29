using System;
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

    private void OnEnable() => VolumeSlider.OnMusicVolumeChange += SetVolume;

    private void OnDisable() => VolumeSlider.OnMusicVolumeChange -= SetVolume;
    #endregion
    
    #region CLASS METHODS
    private void SetVolume(float volume) => audioSource.volume = volume;
    #endregion
}