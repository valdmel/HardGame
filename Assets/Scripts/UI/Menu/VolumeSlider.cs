using System;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    #region VARIABLES
    private const string MusicVolumeKey = "MusicVolume";
    
    public static Action<float> OnVolumeChange;

    #region SERIALIZABLE
    [Header("Volume Properties")]
    [SerializeField] private Slider musicVolumeSlider;
    #endregion
    #endregion
    
    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        musicVolumeSlider.onValueChanged.AddListener(SetVolume);
        
        if (!PlayerPrefs.HasKey(MusicVolumeKey)) return;
        
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey);
    }
    
    private void OnDisable() => musicVolumeSlider.onValueChanged.RemoveAllListeners();
    #endregion
    
    #region CLASS METHODS
    private void SetVolume(float volume)
    {
        musicVolumeSlider.value = volume;
        
        PlayerPrefs.SetFloat(MusicVolumeKey, musicVolumeSlider.value);
        OnVolumeChange?.Invoke(musicVolumeSlider.value);
    }
    #endregion
}
