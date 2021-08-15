using UnityEngine;

namespace OmegaEngine.Core.Commons
{
    public sealed class DetachableAudioSource : MonoBehaviour
    {
        #region VARIABLES
        private AudioSource audioSource;
        #endregion

        #region MONOBEHAVIOUR CALLBACK METHODS
        private void Awake() => audioSource = GetComponent<AudioSource>();
        #endregion

        #region CLASS METHODS
        public void PlayOneShot(AudioClip audioClip)
        {
            DetachFromParentGameObject();

            audioSource.clip = audioClip;

            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length);
        }

        private void DetachFromParentGameObject() => transform.parent = null;
        #endregion
    }
}