using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameConfig config;
    GameMainUI mainUI;
    GameCreateBlock block;

    void Start()
    {
        config = GetComponent<GameConfig>();
        mainUI = GetComponent<GameMainUI>();
        block = GetComponent<GameCreateBlock>();
        ReStart();
    }

    public void ReStart()
    {
        block.ReSet();
        config.ReSet();
        mainUI.Start();
        Debug.LogError("RESTART");
    }

    void Update()
    {
        
    }
}
