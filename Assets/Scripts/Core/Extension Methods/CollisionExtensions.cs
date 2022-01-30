using UnityEngine;

public static class CollisionExtensions
{
    #region VARIABLES
    private const string PlayerBodyTag = "PlayerBody";
    private const string BombTag = "Bomb";
    #endregion

    #region CLASS METHODS
    public static bool WasWithPlayerBody(this Collider other) => other.CompareTag(PlayerBodyTag);
    
    public static bool WasWithBomb(this Collider other) => other.CompareTag(BombTag);
    #endregion
}
