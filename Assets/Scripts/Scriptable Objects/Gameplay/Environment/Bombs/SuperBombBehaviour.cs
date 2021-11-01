using UnityEngine;

[CreateAssetMenu(menuName = "Game/Super Bomb Behaviour", fileName = "SuperBombBehaviour")]
public class SuperBombBehaviour : BombBehaviour
{
    #region CLASS METHODS
    public override void ApplyTo(GameObject objectToBeAffected)
    {
        PlayerBody.onPlayerTouchSuperBomb?.Invoke();
        base.ApplyTo(objectToBeAffected);
    }
    #endregion
}