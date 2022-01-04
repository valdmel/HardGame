using UnityEngine;

public class ExitMenu : MonoBehaviour
{
    #region CLASS METHODS
    public void ExitToMainMenu() => Destroy(GameManager.Instance.gameObject);
    #endregion
}
