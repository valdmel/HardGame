using UnityEngine;

public static class CollisionExtensions
{
    #region VARIABLES
    private const string PlayerBodyTag = "PlayerBody";
    #endregion

    #region CLASS METHODS
    public static bool WasWithPlayerBody(this Collider other) => other.CompareTag(PlayerBodyTag);
    #endregion
}
