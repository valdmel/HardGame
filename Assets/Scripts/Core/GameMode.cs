using UnityEngine;

public class GameMode : MonoBehaviour
{
    #region CLASS METHODS
    public void StartNormalGame() => GameManager.Instance.ActivateNormalGameMode();

    public void StartSpeedrunGame() => GameManager.Instance.ActivateSpeedrunGameMode();
    #endregion
}