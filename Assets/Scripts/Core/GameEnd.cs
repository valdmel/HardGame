using UnityEngine;

public class GameEnd : MonoBehaviour
{
    #region CLASS METHODS
    public void ExitToMainMenu()
    {
        Destroy(GameManager.Instance.gameObject);
        Destroy(TimeManager.Instance.gameObject);
    }
    #endregion
}
