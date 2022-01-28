
using UnityEngine.SceneManagement;

public static class SceneExtension
{
    #region CLASS METHODS
    public static bool IsFirst(this Scene scene) => scene.buildIndex == 0;
    #endregion
}