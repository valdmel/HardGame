using UnityEngine;

[CreateAssetMenu(menuName = "Game/Super Bomb Behaviour", fileName = "SuperBombBehaviour")]
public class SuperBombBehaviour : BombBehaviour
{
    #region CLASS METHODS
    public override void Execute(GameObject objectToBeAffected)
    {
        var playerBodyObject = objectToBeAffected.GetComponent<PlayerBody>();

        PlayerBody.onPlayerTouchSuperBomb?.Invoke();
        playerBodyObject.Kill();
    }
    #endregion
}