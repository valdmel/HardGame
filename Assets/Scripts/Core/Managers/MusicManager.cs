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
    #endregion
}