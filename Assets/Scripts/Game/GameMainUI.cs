using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XftWeapon;

public class GameMainUI : MonoBehaviour
{
    public GameObject Button_Start;
    public GameObject Button_Pause;
    public GameObject Button_Play;
    public GameObject Text_pro;
    public GameObject Panel_MainUI;
    public GameObject Panel_VictoryUI;
    public GameObject Panel_FaileUI;
    public GameConfig config;
    public XWeaponTrail SimpleTrail;


    public void Start()
    {
        Button_Pause.SetActive(false);
        Button_Start.SetActive(true);
        Button_Play.SetActive(false);
        Text_pro.SetActive(false);
        Panel_VictoryUI.SetActive(false);
        Panel_FaileUI.SetActive(false);
        Panel_MainUI.SetActive(true);

        SimpleTrail.Init();
    }

    public void ClickPlayBtn()
    {
        config.SetStart(true);
        config.Start = true;
        Button_Pause.SetActive(true);
        Button_Play.SetActive(false);
    }

    public void ClickPauseBtn()
    {
        config.SetStart(false);
        config.Start = false;
        Button_Pause.SetActive(false);
        Button_Play.SetActive(true);
    }

    public void ClickStartBtn()
    {
        config.SetStart(true);
        config.Start = true;
        Button_Start.SetActive(false);
        Button_Play.SetActive(false);
        Button_Pause.SetActive(true);
        Text_pro.SetActive(true);
    }

    private void OnVictory()
    {
        Panel_MainUI.SetActive(false);
        Panel_FaileUI.SetActive(false);
        Panel_VictoryUI.SetActive(true);
    }

    private void OnGameOver()
    {
        Panel_MainUI.SetActive(false);
        Panel_VictoryUI.SetActive(false);
        Panel_FaileUI.SetActive(true);
    }

    void OnGUI()
    {
        //if (GUI.Button(new Rect(0, 120, 150, 30), "Activate Trail1"))
        //{
        //  SimpleTrail.Activate();
        //}
    }

    private void Update()
    {
        Text_pro.GetComponent<Text>().text = config.GetProcess() + "%";

        if (config.GetResult() == 1)
        {
            OnVictory();
        }

        if (config.GetResult() == 2)
        {
            OnGameOver();
        }
    }

}
