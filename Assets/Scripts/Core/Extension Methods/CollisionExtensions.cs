using UnityEngine;

public static class CollisionExtensions
{
    #region VARIABLES
    private const string PLAYER_BODY_TAG = "PlayerBody";
    #endregion

    #region CLASS METHODS
    public static bool WasWithPlayerBody(this Collider other) => other.CompareTag(PLAYER_BODY_TAG);
    #endregion
}
