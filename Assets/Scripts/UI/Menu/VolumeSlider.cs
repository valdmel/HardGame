using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    #region VARIABLES
    private const string MusicVolumeKey = "MusicVolume";
    private const string SfxVolumeKey = "SfxVolume";
    
    public static Action<float> OnMusicVolumeChange;
    public static Action<float> OnSfxVolumeChange;

    #region SERIALIZABLE
    [Header("Volume Properties")]
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    #endregion
    #endregion
    
    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSfxVolume);
        
        if (!PlayerPrefs.HasKey(MusicVolumeKey) || !PlayerPrefs.HasKey(SfxVolumeKey)) return;
        
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat(SfxVolumeKey);
    }

    private void OnDisable()
    {
        musicVolumeSlider.onValueChanged.RemoveAllListeners();
        sfxVolumeSlider.onValueChanged.RemoveAllListeners();
    }

    #endregion
    
    #region CLASS METHODS
    private void SetMusicVolume(float volume)
    {
        musicVolumeSlider.value = volume;
        
        PlayerPrefs.SetFloat(MusicVolumeKey, musicVolumeSlider.value);
        OnMusicVolumeChange?.Invoke(musicVolumeSlider.value);
    }
    
    private void SetSfxVolume(float volume)
    {
        sfxVolumeSlider.value = volume;
        
        PlayerPrefs.SetFloat(SfxVolumeKey, sfxVolumeSlider.value);
        OnSfxVolumeChange?.Invoke(sfxVolumeSlider.value);
    }
    #endregion
}
