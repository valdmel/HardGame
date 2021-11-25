using UnityEngine;

public class Bomb : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Type Properties")]
    [SerializeField] private BombType bombType;
    #endregion
    #endregion

    #region CLASS METHODS
    public void ApplyTypeBehaviourTo(GameObject gameObject) => bombType.ApplyTo(gameObject);
    #endregion
}