using UnityEngine;

[CreateAssetMenu(menuName = "Game/Bomb Speed", fileName = "BombSpeed")]
public class BombSpeed : ScriptableObject
{
    #region VARIABLES
    #region SERIALIZABLE
    [Header("Speed Properties")]
    [SerializeField] private float moveSpeed = 1f;
    #endregion

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    #endregion
}
