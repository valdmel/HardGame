using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region CLASS METHODS
    public void StartNormalGame() => GameManager.Instance.ActivateNormalGameMode();

    public void StartSpeedrunGame() => GameManager.Instance.ActivateSpeedrunGameMode();
    #endregion
}