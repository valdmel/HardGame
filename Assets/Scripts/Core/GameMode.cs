using UnityEngine;

public enum GameModeIndex
{
    Normal = 0,
    Speedrun = 1
}

public class GameMode : MonoBehaviour
{
    #region VARIABLES

    #endregion
    
    #region CLASS METHODS
    public void StartNormalGame() => GameManager.Instance.activeGameMode = (int)GameModeIndex.Normal;

    public void StartSpeedrunGame() => GameManager.Instance.activeGameMode = (int)GameModeIndex.Speedrun;
    #endregion
}