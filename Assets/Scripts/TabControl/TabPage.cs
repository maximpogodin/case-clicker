using UnityEngine;

public class TabPage : MonoBehaviour
{
    private Animator animator;
    public bool IsShowed;
    [SerializeField]
    private bool _isAnimated;
    public bool IsStartPage;

    [SerializeField]
    private BackpackAnimator _backpackAnimator; 

    private void Awake()
    {
        if (_isAnimated)
            animator = GetComponent<Animator>();

        IsShowed = false;
    }

    private void OnDisable()
    {
        _backpackAnimator.PlayAnimation();
    }

    private void OnEnable()
    {
        _backpackAnimator.PlayAnimation();
    }

    public void ShowOrHidePage()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        //if (!gameObject.activeSelf)
        //{
        //    //gameObject.SetActive(true);

        //    //if (_isAnimated)
        //    //    animator.SetBool("Show", true);
        //}
        //else
        //{
        //    //gameObject.SetActive(false);

        //    //if (_isAnimated)
        //    //    animator.SetBool("Show", false);
        //    //else
        //    //    gameObject.SetActive(false);
        //}
    }

    public void DeactivatePage()
    {
        gameObject.SetActive(false);
    }
}