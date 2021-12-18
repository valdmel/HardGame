using UnityEngine;

[CreateAssetMenu(menuName = "Game/Super Bomb", fileName = "SuperBomb")]
public class SuperBomb : BombType
{
    #region CLASS METHODS
    public override void ApplyTo(GameObject objectToBeAffected)
    {
        PlayerBody.OnPlayerTouchSuperBomb?.Invoke();
        base.ApplyTo(objectToBeAffected);
    }
    #endregion
}