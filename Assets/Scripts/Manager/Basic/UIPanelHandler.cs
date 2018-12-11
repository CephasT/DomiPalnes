using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class UIPanelHandler : MonoBehaviour {

    [Header("Panel Kind")]
    public UIManager.PanelKind Kind;

    public CanvasGroup canvasGroup;    
    

    private void Start()
    {       
        canvasGroup = GetComponent<CanvasGroup>();
        GameCore.GetSystem<UIManager>().SetUIPanel(this);

        if (canvasGroup.alpha == 0) {
            gameObject.SetActive(false);
        }
    }
   
}
