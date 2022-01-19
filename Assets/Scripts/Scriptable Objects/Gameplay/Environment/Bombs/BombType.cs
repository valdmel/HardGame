using UnityEngine;

public abstract class BombType : ScriptableObject
{
    #region CLASS METHODS
    public virtual void ApplyTo(GameObject affectedObject)
    {
        var playerBody = affectedObject.GetComponent<IKillable>();

        playerBody.Kill();
    }
    #endregion
}