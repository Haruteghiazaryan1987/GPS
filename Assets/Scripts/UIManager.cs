using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Manager manager;
    public event Action OnSearchButtonClicked;
    public event Action OnUpdateButtonClicked;
    public event Action OnViewPanelMap;
    
    [Space(5), Header("View System")] 
    [SerializeField] private View panelLoginMenu;
    [SerializeField] private View panelPersonalInformation;
    [SerializeField] private View panelMap;
    
    private View activeView;
    
    public void Setup(Manager manager){
        this.manager = manager;
        InitsPanel();
        ShowViewPanel(panelLoginMenu);
    }

    private void InitsPanel(){
        panelLoginMenu.Setup(this);
        panelPersonalInformation.Setup(this);
        panelMap.Setup(this);
    }
    private void ShowViewPanel(View view){
        if (activeView != null)
            activeView.HideView();
        activeView = view;
        view.ShowView();
    }

    public void ViewPanelMap(){
        ShowViewPanel(panelMap);
        OnViewPanelMap?.Invoke();
    }

    public void ViewPanelPersonalInformation(){
        ShowViewPanel(panelPersonalInformation);
    }
    public void ViewPanelLoginMenu(){
        ShowViewPanel(panelLoginMenu);
    }

    public void ButtonSearchClick(){
        OnSearchButtonClicked?.Invoke();
    }
    public void ButtonUpdateClick(){
        OnUpdateButtonClicked?.Invoke();
    }
}
