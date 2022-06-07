using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((data) => { ScaleDown(); });
        trigger.triggers.Add(entryDown);

        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener((data) => { ScaleUp(); });
        trigger.triggers.Add(entryUp);

        _animator = GetComponent<Animator>();
    }

    public void ScaleUp()
    {
        _animator.SetBool("Pressed", false);
    }

    public void ScaleDown()
    {
        _animator.SetBool("Pressed", true);

    }
}