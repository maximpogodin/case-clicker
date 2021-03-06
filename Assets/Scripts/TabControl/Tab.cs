using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    private TabControl tabControl;
    private int tabIndex;

    private void Awake()
    {
        tabControl = transform.parent.parent.GetComponent<TabControl>();
        tabIndex = tabControl.GetTabIndex(this);
        GetComponent<Button>().onClick.AddListener(ShowPage);
    }

    public void ShowPage()
    {
        tabControl.ShowPage(tabIndex);
    }
}