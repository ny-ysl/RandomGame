using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Con_btn : MonoBehaviour
{
    public GameObject Panel_Help;
    public GameObject Panel_Setting;

    public Button Button_Start;
    public Button Button_Help;
    public Button Button_Setting;

    public Button Help_CloseBtn;
    public Button Setting_CloseBtn;

    public void ClickStartBtn()
    {
        Debug.Log("ClickStartGame unity");
    }

    public void CloseSettingView()
    {
        Panel_Setting.SetActive(false);
    }

    public void ClickSettingBtn()
    {
        Debug.Log("ClickHelpGame unity");
        Panel_Setting.SetActive(true);
    }

    public void CloseHelpView()
    {
        Panel_Help.SetActive(false);
    }

    public void ClickHelpBtn()
    {
        Debug.Log("ClickHelpGame unity");
        Panel_Help.SetActive(true);
    }



}


