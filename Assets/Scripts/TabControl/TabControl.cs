using System;
using UnityEngine;
using UnityEngine.UI;

public class TabControl : MonoBehaviour
{
    [SerializeField]
    private TabPage[] tabPages;
    [SerializeField]
    private Tab[] tabs;

    private void Awake()
    {
        if (GetComponent<Button>() != null)
            GetComponent<Button>().onClick.AddListener(Close);

        for (int i = 0; i < tabPages.Length; i++)
        {
            tabPages[i].gameObject.SetActive(tabPages[i].IsStartPage);
        }
    }

    public void Close()
    {
        for (int i = 0; i < tabPages.Length; i++)
        {
            if (tabPages[i].gameObject.activeSelf)
            {
                tabPages[i].ShowOrHidePage();
            }
        }
    }

    public int GetTabIndex(Tab tab)
    {
        return Array.FindIndex(tabs, t => t == tab);
    }

    public void ShowPage(int index)
    {
        tabPages[index].ShowOrHidePage();
        //tabPages[index].IsShowed = true;

        //tabPages[index].ShowOrHidePage();

        for (int i = 0; i < tabPages.Length; i++)
        {
            if (i != index)
            {
                if (tabPages[i].gameObject.activeSelf)
                {
                    tabPages[i].ShowOrHidePage();
                }
            }
        }
    }
}