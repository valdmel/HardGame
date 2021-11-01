using UnityEngine;

[CreateAssetMenu(menuName = "Game/Normal Bomb Behaviour", fileName = "NormalBombBehaviour")]
public class NormalBombBehaviour : BombBehaviour
{
    #region CLASS METHODS
    public override void ApplyTo(GameObject objectToBeAffected)
    {
        PlayerBody.onPlayerTouchBomb?.Invoke();
        base.ApplyTo(objectToBeAffected);
    }
    #endregion
}