using UnityEngine;

public abstract class BombBehaviour : ScriptableObject
{
    #region CLASS METHODS
    public abstract void Execute(GameObject objectToBeAffected);
    #endregion
}