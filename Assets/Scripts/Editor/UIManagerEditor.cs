using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UIManagerEditor : EditorWindow
{
    public Dictionary<string, UIPanelHandler> PanelList = new Dictionary<string, UIPanelHandler>();

    private UIPanelHandler[] handler;
    private Toggle[] panelToggle;
    private bool[] PanelActive;   
    private bool groupEnabled;

    [MenuItem("UI/UIManager Controller")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(UIManagerEditor), false, "UI Controller");
    }

    private void Awake()
    {

    }

    private void OnGUI()
    {
        if (GUILayout.Button("init")) {
            initialize();
        }

        for (int i=0; i< handler.Length; i++) {
            EditorGUILayout.BeginHorizontal();            
            PanelActive[i] = EditorGUILayout.Toggle(handler[i].name+"<"+ handler[i].tag+ ">", handler[i].gameObject.activeSelf);            
            //PanelActive[i] = handler[i].gameObject.activeSelf;
            if (PanelActive[i])
            {
                handler[i].gameObject.SetActive(true);
            }
            else {
                handler[i].gameObject.SetActive(false);
            }            

            EditorGUILayout.ObjectField("", handler[i], typeof(UIPanelHandler), false);
            EditorGUILayout.EndHorizontal();
        }
    }

    private void OnEnable()
    {
        initialize();
    }

    private void initialize() {
        handler = FindObjectsOfType<UIPanelHandler>();
        PanelActive = new bool[handler.Length];
        panelToggle = new Toggle[handler.Length];        
    }
}
