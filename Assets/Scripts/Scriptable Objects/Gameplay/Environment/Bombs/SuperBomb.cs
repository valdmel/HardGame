using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Super BombMovement", fileName = "SuperBomb")]
public class SuperBomb : BombBehaviour
{
    #region CLASS METHODS
    public override void ApplyTo(GameObject objectToBeAffected)
    {
        PlayerBody.OnPlayerTouchSuperBomb?.Invoke();
        base.ApplyTo(objectToBeAffected);
    }
    #endregion
}