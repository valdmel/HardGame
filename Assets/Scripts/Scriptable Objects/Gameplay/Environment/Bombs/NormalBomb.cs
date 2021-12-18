using UnityEngine;

[CreateAssetMenu(menuName = "Game/Normal Bomb", fileName = "NormalBomb")]
public class NormalBomb : BombType
{
    #region CLASS METHODS
    public override void ApplyTo(GameObject objectToBeAffected)
    {
        PlayerBody.OnPlayerTouchBomb?.Invoke();
        base.ApplyTo(objectToBeAffected);
    }
    #endregion
}