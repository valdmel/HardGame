using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Player Speed", fileName = "PlayerSpeed")]
public class PlayerSpeed : ScriptableObject
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Speed Properties")]
    [SerializeField, Range(0, 20)] private int moveSpeed = 5;
    #endregion

    public int MoveSpeed
    {
        get => moveSpeed;
        private set => moveSpeed = value;
    }
    #endregion
}
