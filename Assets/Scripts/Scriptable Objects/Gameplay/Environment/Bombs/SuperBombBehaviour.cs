using UnityEngine;

[CreateAssetMenu(menuName = "Game/Super Bomb Behaviour", fileName = "SuperBombBehaviour")]
public class SuperBombBehaviour : BombBehaviour
{
    #region CLASS METHODS
    public override void Execute(GameObject objectToBeAffected)
    {
        PlayerBody.onPlayerTouchSuperBomb?.Invoke();
        base.Execute(objectToBeAffected);
    }
    #endregion
}