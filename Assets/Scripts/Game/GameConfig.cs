using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public bool Start = false; 
    public int Process = 0; //进度
    public int Result = 0;  //1 victory 2 gameover
    public int StarNum = 1; 

    public void ReSet()
    {
        Start = false;
        Process = 0;
        Result = 0;
        StarNum = 1;
    }

    public void SetProcess(int pro)
    {
        Process = pro;
    }

    public int GetProcess()
    {
        return Process;
    }

    public void SetStart(bool _isS)
    {
        Start = _isS;
    }

    public bool GetStart()
    {
        return Start;
    }

    public void SetResult(int rel)
    {
        Result = rel;
    }

    public int GetResult()
    {
        return Result;
    }


    public void SetStarNum(int starnum)
    {
        StarNum = starnum;
    }

    public int GetStarNum()
    {
        return StarNum;
    }


}
