using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    #region VARIABLES
    private const float VolumeLogFactor = 20f;
    private const string AudioMixerMusicExposedParameter = "MusicVolume";
    private const string AudioMixerSfxExposedParameter = "SfxVolume";

    #region SERIALIZABLE
    [Header("Audio Properties")]
    [SerializeField] private AudioMixer audioMixer;
    [Header("Slider Properties")]
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable()
    {
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSfxVolume);
    }

    private void Start() => LoadSliderValues();

    private void OnDisable()
    {
        musicVolumeSlider.onValueChanged.RemoveAllListeners();
        sfxVolumeSlider.onValueChanged.RemoveAllListeners();
    }
    #endregion
    
    #region CLASS METHODS
    private void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(AudioMixerMusicExposedParameter, CalculateLogVolumeFrom(volume));
        PlayerPrefs.SetFloat(AudioMixerMusicExposedParameter, musicVolumeSlider.value);
    }
    
    private void SetSfxVolume(float volume)
    {
        audioMixer.SetFloat(AudioMixerSfxExposedParameter, CalculateLogVolumeFrom(volume));
        PlayerPrefs.SetFloat(AudioMixerSfxExposedParameter, sfxVolumeSlider.value);
    }
    
    private void LoadSliderValues()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat(AudioMixerMusicExposedParameter, musicVolumeSlider.value);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat(AudioMixerSfxExposedParameter, sfxVolumeSlider.value);
    }
    
    private float CalculateLogVolumeFrom(float volume) => Mathf.Log10(volume) * VolumeLogFactor;
    #endregion
}
