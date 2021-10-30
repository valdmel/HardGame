using UnityEngine;

public abstract class BombBehaviour : ScriptableObject
{
    #region CLASS METHODS
    public virtual void Execute(GameObject objectToBeAffected)
    {
        var playerBodyObject = objectToBeAffected.GetComponent<PlayerBody>();

        playerBodyObject.Kill();
    }
    #endregion
}