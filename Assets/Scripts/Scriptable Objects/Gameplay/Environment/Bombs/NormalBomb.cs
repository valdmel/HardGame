using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Normal Bomb", fileName = "NormalBomb")]
public class NormalBomb : BombType
{
    #region CLASS METHODS
    public override void ApplyTo(GameObject objectToBeAffected)
    {
        base.ApplyTo(objectToBeAffected);
    }
    #endregion
}