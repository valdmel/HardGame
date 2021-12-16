using UnityEngine;
using UnityEngine.Events;

public class BombTrigger : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Events Properties")]
    [SerializeField] private UnityEvent onEnter;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnTriggerEnter(Collider other)
    {
        if (other.WasWithPlayerBody())
        {
            onEnter?.Invoke();
            gameObject.SetActive(false);
        }
    }
    #endregion
}
