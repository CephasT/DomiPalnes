using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : IGameSystemMono {
    
    //Canves GameObject
    public GameObject m_CanvasRoot;

    //Panel List
    public List<UIPanelHandler> PanelList = new List<UIPanelHandler>();

    public Dictionary<string, UIPanelHandler> static_PanelList = new Dictionary<string, UIPanelHandler>();
    public Dictionary<string, UIPanelHandler> dynamic_PanelList = new Dictionary<string, UIPanelHandler>();

    //Panel kind
    public enum PanelKind { StaticPanel, DynamicPanel}

    public void SetUIPanel(UIPanelHandler obj) {
        if (obj.Kind == PanelKind.StaticPanel) {
            static_PanelList.Add(obj.gameObject.name, obj);            
        }

        if (obj.Kind == PanelKind.DynamicPanel) {
            dynamic_PanelList.Add(obj.gameObject.name, obj); 
        }

        PanelList.Add(obj);        
    }

    //Open Panel
    public void ShowPanel(string name)
    {
        TogglePanel(name, true);
    }

    //Close Panel
    public void ClosePanel(string name)
    {
        TogglePanel(name, false);
    }

    public void UIManagerInitialize() {
        PanelList.Clear();
        static_PanelList.Clear();
        dynamic_PanelList.Clear();
    }

    #region IGameSystemMono override
    public override void DestoryGameSystem() { }

    public override void StartGameSystem() {}
    #endregion

    #region Toggle Panel
    public void TogglePanel(string name, bool isOn)
    {        

        if (!IsPanelLive(name))
        {
            Debug.Log("[UIManager]There is no Panel named " + name);
        }

        if (static_PanelList.ContainsKey(name))
        {
            if (!isOn)
            {
                static_PanelList[name].canvasGroup.alpha = 0;
                static_PanelList[name].gameObject.SetActive(false);
            }
            else {
                static_PanelList[name].canvasGroup.alpha = 1;
                static_PanelList[name].gameObject.SetActive(true);
            }            
        }

        if (dynamic_PanelList.ContainsKey(name))
        {
            if (!isOn)
            {
                dynamic_PanelList[name].canvasGroup.alpha = 0;
                dynamic_PanelList[name].gameObject.SetActive(false);
            }
            else
            {
                dynamic_PanelList[name].canvasGroup.alpha = 1;
                dynamic_PanelList[name].gameObject.SetActive(true);
            }
        }        
    }

    public void TogglePanel(string name)
    {

        if (!IsPanelLive(name))
        {
            Debug.Log("[UIManager]There is no Panel named " + name);
        }

        if (static_PanelList.ContainsKey(name))
        {
            if (static_PanelList[name].canvasGroup.alpha == 1)
            {
                static_PanelList[name].canvasGroup.alpha = 0;
                static_PanelList[name].gameObject.SetActive(false);
            }
            else
            {
                static_PanelList[name].canvasGroup.alpha = 1;
                static_PanelList[name].gameObject.SetActive(true);
            }
        }

        if (dynamic_PanelList.ContainsKey(name))
        {
            if (dynamic_PanelList[name].canvasGroup.alpha == 1)
            {
                dynamic_PanelList[name].canvasGroup.alpha = 0;
                dynamic_PanelList[name].gameObject.SetActive(false);
            }
            else
            {
                dynamic_PanelList[name].canvasGroup.alpha = 1;
                dynamic_PanelList[name].gameObject.SetActive(true);
            }
        }
    }
    #endregion

    #region Private Function
    private bool IsPanelLive(string name)
    {
        return static_PanelList.ContainsKey(name) || dynamic_PanelList.ContainsKey(name);
    }
    #endregion

}
