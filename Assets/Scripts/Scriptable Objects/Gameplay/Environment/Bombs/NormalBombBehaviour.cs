using UnityEngine;

[CreateAssetMenu(menuName = "Game/Normal Bomb Behaviour", fileName = "NormalBombBehaviour")]
public class NormalBombBehaviour : BombBehaviour
{
    #region CLASS METHODS
    public override void Execute(GameObject objectToBeAffected)
    {
        var playerBodyObject = objectToBeAffected.GetComponent<PlayerBody>();

        PlayerBody.onPlayerTouchBomb?.Invoke();
        playerBodyObject.Kill();
    }
    #endregion
}