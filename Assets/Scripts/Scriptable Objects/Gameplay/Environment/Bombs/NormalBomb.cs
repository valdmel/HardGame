using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Normal BombMovement", fileName = "NormalBomb")]
public class NormalBomb : BombType
{
    #region CLASS METHODS
    public override void ApplyTo(GameObject objectToBeAffected)
    {
        base.ApplyTo(objectToBeAffected);
    }
    #endregion
}