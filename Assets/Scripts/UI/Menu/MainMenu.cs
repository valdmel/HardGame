using UnityEngine;

public sealed class MainMenu : MonoBehaviour
{
    #region VARIABLES
    #region SERIALIZABLE
    /*    [Header("Menu Properties")]*/
    #endregion
    #endregion

    #region CLASS METHODS
    public void StartNewGame() => GameManager.Instance.StartNewGame();
    #endregion
}