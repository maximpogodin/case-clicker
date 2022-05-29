using System;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TabControl : MonoBehaviour
{
    [SerializeField]
    private TabPage[] tabPages;
    [SerializeField]
    private Tab[] tabs;

    private int currentPageIndex;

    private void Awake()
    {
        Disable();
        currentPageIndex = -1;

        foreach (TabPage item in tabPages)
        {
            item.gameObject.SetActive(true);
        }
    }

    public int GetTabIndex(Tab tab)
    {
        return Array.FindIndex(tabs, t => t == tab);
    }

    public void ShowPage(int index)
    {
        //close current page
        if (currentPageIndex == index)
        {
            tabPages[currentPageIndex].ShowOrHidePage();
            currentPageIndex = -1;
            return;
        }

        //close already opened page, if exists
        if (currentPageIndex != index && currentPageIndex != -1)
        {
            tabPages[currentPageIndex].ShowOrHidePage();
        }

        //open page
        currentPageIndex = index;
        tabPages[currentPageIndex].ShowOrHidePage();
    }

    public void Disable()
    {
        GetComponent<Image>().enabled = false;
    }

    public void Enable()
    {
        GetComponent<Image>().enabled = true;
    }
}