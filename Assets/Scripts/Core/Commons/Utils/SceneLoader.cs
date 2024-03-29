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

    #region CLASS METHODS
    public void LoadNextScene() => StartCoroutine(LoadScene(NextSceneIndex));

    public void LoadPreviousScene() => StartCoroutine(LoadScene(PreviousSceneIndex));

    public void LoadSceneFromIndex(int sceneIndexToLoad) => StartCoroutine(LoadScene(sceneIndexToLoad));
    
    public void RestartScene() => StartCoroutine(LoadScene(CurrentSceneIndex));

    private IEnumerator LoadScene(int sceneIndexToLoad)
    {
        activeTransition.ContinueTransition();

        yield return new WaitUntil(() => activeTransition.IsFinished);

        SceneManager.LoadScene(sceneIndexToLoad);
    }
    #endregion
}