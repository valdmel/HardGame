using UnityEngine;

[CreateAssetMenu(menuName = "Game/Bomb Direction", fileName = "BombDirection")]
public class BombDirection : ScriptableObject
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Direction Properties")]
    [SerializeField] private Vector3 moveDirection;
    #endregion

    public Vector3 MoveDirection { get => moveDirection; set => moveDirection = value; }
    #endregion
}
