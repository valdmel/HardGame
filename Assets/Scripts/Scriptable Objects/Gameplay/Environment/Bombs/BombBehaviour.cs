using UnityEngine;

public abstract class BombBehaviour : ScriptableObject
{
    #region CLASS METHODS
    public virtual void ApplyTo(GameObject affectedObject)
    {
        var playerBodyObject = affectedObject.GetComponent<PlayerBody>();

        playerBodyObject.Kill();
    }
    #endregion
}