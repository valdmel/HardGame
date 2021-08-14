using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TransitionEffect : MonoBehaviour
{
    #region VARIABLES
    private const string FINISH_TRANSITION_TRIGGER = "FinishTransition";
    private const float ANIMATOR_STOP_SPEED = 0;

    #region SERIALIZABLE
    [Header("Events Properties")]
    public UnityEvent OnStartTransitionFirstAnimationFrame;
    public UnityEvent OnStartTransitionLastAnimationFrame;
    public UnityEvent OnFinishTransitionFirstAnimationFrame;
    public UnityEvent OnFinishTransitionLastAnimationFrame;
    [Header("Transition Effect Properties")]
    [SerializeField] private Animator animator;
    [SerializeField, Range(0, 1)] private float transitionSpeed = 1f;
    [SerializeField, Min(0)] private float transitionDurationInSeconds = 1f;
    #endregion

    private bool isFinished = false;

    public bool IsFinished { get => isFinished; }
    #endregion

    #region MONOBEHAVIOUR CALLBACK METHODS
    private void Start() => StartCoroutine(PlayTransitionAnimation());
    #endregion

    #region CLASS METHODS
    public void ContinueTransition()
    {
        animator.SetTrigger(FINISH_TRANSITION_TRIGGER);
        StartCoroutine(PlayTransitionAnimation());
    }

    private IEnumerator PlayTransitionAnimation()
    {
        animator.speed = ANIMATOR_STOP_SPEED;

        yield return new WaitForSeconds(transitionDurationInSeconds);

        animator.speed = transitionSpeed;
    }

    private void FinishTransitionLastAnimationFrame()
    {
        isFinished = true;

        OnFinishTransitionLastAnimationFrame?.Invoke();
    }

    private void StartTransitionFirstAnimationFrame() => OnStartTransitionFirstAnimationFrame?.Invoke();

    private void StartTransitionLastAnimationFrame() => OnStartTransitionLastAnimationFrame?.Invoke();

    private void FinishTransitionFirstAnimationFrame() => OnFinishTransitionFirstAnimationFrame?.Invoke();
    #endregion
}