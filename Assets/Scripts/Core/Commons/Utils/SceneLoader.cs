using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region VARIABLES
    public static int CurrentSceneIndex => SceneManager.GetActiveScene().buildIndex;
    public static int NextSceneIndex => CurrentSceneIndex + 1;
    public static int PreviousSceneIndex => CurrentSceneIndex - 1;

    #region SERIALIZABLE
    [Header("Transition Effect Properties")]
    [SerializeField] private TransitionEffect activeTransition;
    #endregion
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void OnEnable() => PlayerBody.onPlayerDeath += RestartScene;

    private void OnDisable() => PlayerBody.onPlayerDeath -= RestartScene;
    #endregion

    #region CLASS METHODS
    public void LoadNextScene() => StartCoroutine(LoadScene(NextSceneIndex));

    public void LoadPreviousScene() => StartCoroutine(LoadScene(PreviousSceneIndex));

    public void RestartScene() => StartCoroutine(LoadScene(CurrentSceneIndex));

    private IEnumerator LoadScene(int sceneIndexToLoad)
    {
        activeTransition.ContinueTransition();

        yield return new WaitUntil(() => activeTransition.IsFinished);

        SceneManager.LoadScene(sceneIndexToLoad);
    }
    #endregion
}