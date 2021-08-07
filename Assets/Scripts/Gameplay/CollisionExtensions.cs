using UnityEngine;

public static class CollisionExtensions
{
    #region VARIABLES
    private const string PLAYER_BODY_TAG = "PlayerBody";
    private const string BOMB_TAG = "Bomb";
    private const string LEVEL_WALLS_TAG = "Level";
    #endregion

    #region CLASS METHODS
    public static bool WasWithPlayerBody(this Collider other) => other.CompareTag(PLAYER_BODY_TAG);

    public static bool WasWithBomb(this Collider other) => other.CompareTag(BOMB_TAG);

    public static bool WasWithLevelWalls(this Collider other) => other.CompareTag(LEVEL_WALLS_TAG);
    #endregion
}
