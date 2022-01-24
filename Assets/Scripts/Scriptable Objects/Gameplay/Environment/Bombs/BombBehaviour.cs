using UnityEngine;

public abstract class BombBehaviour : ScriptableObject
{
    #region CLASS METHODS
    public virtual void ApplyTo(GameObject affectedObject)
    {
        var playerBody = affectedObject.GetComponent<IKillable>();

        playerBody.Kill();
    }
    #endregion
}