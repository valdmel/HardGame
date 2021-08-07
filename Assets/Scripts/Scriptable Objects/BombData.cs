using UnityEngine;

[CreateAssetMenu(menuName = "Game/Bomb Data", fileName = "BombData")]
public class BombData : ScriptableObject
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Bomb Properties")]
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Vector3 moveDirection;
    #endregion

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public Vector3 MoveDirection { get => moveDirection; set => moveDirection = value; }
    #endregion
}
