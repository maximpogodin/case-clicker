using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    private Animator _transitionAnimator;
    public CamerasManager CamerasManager;

    private void Awake()
    {
        _transitionAnimator = GetComponent<Animator>();

        TransitionPanelSetAsFirstSibling();
    }

    public void RunTransition(bool isForward)
    {
        transform.SetAsLastSibling();

        _transitionAnimator.SetBool("Forwarded", isForward);
    }

    public void TransitionPanelSetAsFirstSibling()
    {
        transform.SetAsFirstSibling();
    }

    public void ReplaceCamera()
    {
        CamerasManager.ReplaceCamera();
    }
}