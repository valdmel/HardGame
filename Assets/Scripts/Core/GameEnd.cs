using UnityEngine;

public class GameEnd : MonoBehaviour
{
    #region CLASS METHODS
    public void ExitToMainMenu() => Destroy(GameManager.Instance.gameObject);
    #endregion
}
