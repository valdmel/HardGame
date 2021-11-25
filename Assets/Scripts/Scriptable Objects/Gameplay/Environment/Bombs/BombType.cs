using UnityEngine;

public abstract class BombType : ScriptableObject
{
    #region CLASS METHODS
    public virtual void ApplyTo(GameObject affectedObject)
    {
        var playerBodyObject = affectedObject.GetComponent<PlayerBody>();

        playerBodyObject.Kill();
    }
    #endregion
}