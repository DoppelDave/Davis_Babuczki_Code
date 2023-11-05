using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public enum Tabs
{
    PresetTerrain,
    CustomTerrain,
}

public class TabDrawer
{
    private List<Tabs> allCategories;
    private string[] allCategoryLabels;
    private Tabs currentlySelectedTab;

    public Tabs CurrentlySelectedTab => currentlySelectedTab;

    public TabDrawer()
    {
        InitTabs();
    }

    public void DrawTabs()
    {
        currentlySelectedTab = allCategories[GUILayout.Toolbar((int)currentlySelectedTab, allCategoryLabels)];
    }

    private void InitTabs()
    {
        Tabs[] enums = (Tabs[])System.Enum.GetValues(typeof(Tabs));

        allCategories = enums.ToList();
        allCategoryLabels = allCategories.ConvertAll(tab => tab.ToString()).ToArray();
    }
}
