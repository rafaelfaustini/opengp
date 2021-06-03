using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;
    public TabButton selectedTab;
    public List<GameObject> contentsToSwap;

    public void Subscribe(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) continue;
            button.background.sprite = tabIdle;
        }
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.sprite = tabHover;
        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button)
    {
        if(selectedTab != null)
        {
            selectedTab.DeSelect();
        }
        selectedTab = button;

        selectedTab.Select();

        selectedTab = button;
        ResetTabs();
        if (button.background == null) return;
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < contentsToSwap.Count; i++)
        {
            if(i == index)
            {
                contentsToSwap[i].SetActive(true);
            }
            else
            {
                contentsToSwap[i].SetActive(false);
            }
        }

    }
}
