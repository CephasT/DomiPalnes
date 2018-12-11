using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : IGameSystemMono {

    public static Dictionary<Type, GameController> GameContorllerList = new Dictionary<Type, GameController>();

    public override void DestoryGameSystem() {

    }

    public override void StartGameSystem() {
        //Initialized at Awake
        GameController[] ControllerList = gameObject.GetComponentsInChildren<GameController>();

        for (int i = 0; i < ControllerList.Length; i++)
        {
            GameContorllerList.Add(ControllerList[i].GetType(), ControllerList[i]);
            ControllerList[i].StartGameController();
        }
    }


    public static T GetController<T>() where T : GameController
    {
        if (GameContorllerList.ContainsKey(typeof(T)))
        {
            return GameContorllerList[typeof(T)] as T;
        }
        else
        {
            Debug.LogError("[GameManager] There was no " + typeof(T).Name);
            return null;
        }
    }
}
