using UnityEngine;

public static class CollisionExtensions
{
    #region VARIABLES
    private const string PLAYER_BODY_TAG = "PlayerBody";
    private const string BOMB_TAG = "Bomb";
    private const string SUPER_BOMB_TAG = "SuperBomb";
    private const string WALL_TAG = "Wall";
    #endregion

    #region CLASS METHODS
    public static bool WasWithPlayerBody(this Collider other) => other.CompareTag(PLAYER_BODY_TAG);

    public static bool WasWithBomb(this Collider other) => other.CompareTag(BOMB_TAG);

    public static bool WasWithSuperBomb(this Collider other) => other.CompareTag(SUPER_BOMB_TAG);

    public static bool WasWithWall(this Collider other) => other.CompareTag(WALL_TAG);
    #endregion
}
