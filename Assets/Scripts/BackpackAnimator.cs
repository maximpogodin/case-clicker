using UnityEngine;

public class BackpackAnimator : MonoBehaviour
{
    private bool _opened;
    private Animator _animator;

    private void Awake()
    {
        _opened = false;
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        _opened = !_opened;
        _animator.SetBool("Opened", _opened);

        Debug.Log(_animator.GetBool("Opened")); 
    }
}