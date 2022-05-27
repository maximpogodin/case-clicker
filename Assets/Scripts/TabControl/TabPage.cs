using UnityEngine;

public class TabPage : MonoBehaviour
{
    private Animator animator;
    private bool isShowed;
    public bool IsShowed
    {
        get { return isShowed; }
        private set { isShowed = value; }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        IsShowed = false;
    }

    public void ShowOrHidePage()
    {
        if (!IsShowed)
        {
            IsShowed = true;
            animator.SetBool("Show", true);
        }
        else
        {
            IsShowed = false;
            animator.SetBool("Show", false);
        }
    }
}