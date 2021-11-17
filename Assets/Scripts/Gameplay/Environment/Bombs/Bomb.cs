using UnityEngine;

public class Bomb : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Behaviour Properties")]
    [SerializeField] private BombBehaviour bombBehaviour;
    #endregion
    #endregion

    #region CLASS METHODS
    public void ExecuteBehaviour(GameObject gameObject) => bombBehaviour.ApplyTo(gameObject);
    #endregion
}