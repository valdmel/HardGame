using UnityEngine;

[CreateAssetMenu(menuName = "Game/Normal Bomb Behaviour", fileName = "NormalBombBehaviour")]
public class NormalBombBehaviour : BombBehaviour
{
    #region CLASS METHODS
    public override void Execute(GameObject objectToBeAffected)
    {
        PlayerBody.onPlayerTouchBomb?.Invoke();
        base.Execute(objectToBeAffected);
    }
    #endregion
}