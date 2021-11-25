using UnityEngine;

[CreateAssetMenu(menuName = "Game/Super Bomb", fileName = "SuperBomb")]
public class SuperBomb : BombType
{
    #region CLASS METHODS
    public override void ApplyTo(GameObject objectToBeAffected)
    {
        PlayerBody.onPlayerTouchSuperBomb?.Invoke();
        base.ApplyTo(objectToBeAffected);
    }
    #endregion
}