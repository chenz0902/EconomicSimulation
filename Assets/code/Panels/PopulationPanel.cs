﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class PopulationPanel :  DragPanel
{
    public GameObject populationPanel;
   // public GameObject ScrollViewMy;
    public ScrollRect table;
    public bool showAll;
    internal Province showingProvince;

    // Use this for initialization
    void Start () {
        MainCamera.populationPanel = this;
        hide();        
    }
    public void hide()
    {
        populationPanel.SetActive(false);
        //todo add button removal?      
    }   
    public void show(bool bringOnTop)
    {
        populationPanel.SetActive(true);
        if ( bringOnTop)
        panelRectTransform.SetAsLastSibling();
    }
    public void onCloseClick()
    {
        hide();
        showAll = false;
    }
    internal void SetAllPopsToShow()
    {
        List<PopUnit> er = new List<PopUnit>();
        //Game.popListToShow.Clear();
        foreach (Province province in Game.player.ownedProvinces)
            foreach (PopUnit popUnit in province.allPopUnits)
                // Game.popListToShow.Add(popUnit);
                er.Add(popUnit);
        Game.popsToShowInPopulationPanel = er;
    }
    public void onShowAllClick()
    {
        hide();
        SetAllPopsToShow();
        showAll = true;
        show(true);            
    }
    public void refresh()
    {
        hide();
        if (showAll)
            SetAllPopsToShow();
        show(false);
    }
    // Update is called once per frame
 //   void Update () {
	
	//}
}
