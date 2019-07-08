using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdper_camera : MonoBehaviour
{
    public float smooth = 3f;       // カメラモーションのスムーズ化用変数
    Transform standardPos;          // the usual position for the camera, specified by a transform in the game
    Transform frontPos;         // Front Camera locater
    Transform jumpPos;			// Jump Camera locater
    bool bQuickSwitch = false;

    void Start()
    {
        standardPos = GameObject.Find("CamPos").transform;

        if (GameObject.Find("FrontPos"))
            frontPos = GameObject.Find("FrontPos").transform;

        if (GameObject.Find("JumpPos"))
            jumpPos = GameObject.Find("JumpPos").transform;

        //transform.position = standardPos.position;
       // transform.forward = standardPos.forward;
    }
    void Update()
    {
        
    }

    void setCameraPositionNormalView()
    {
        if (bQuickSwitch == false)
        {
            transform.position = Vector3.Lerp(transform.position, standardPos.position, Time.fixedDeltaTime * smooth);
            transform.forward = Vector3.Lerp(transform.forward, standardPos.forward, Time.fixedDeltaTime * smooth);
        }
        else
        {
            transform.position = standardPos.position;
            transform.forward = standardPos.forward;
            bQuickSwitch = false;
        }
    }

    void setCameraPositionFrontView()
    {
        bQuickSwitch = true;
        transform.position = frontPos.position;
        transform.forward = frontPos.forward;
    }

    void setCameraPositionJumpView()
    {
        bQuickSwitch = false;
        transform.position = Vector3.Lerp(transform.position, jumpPos.position, Time.fixedDeltaTime * smooth);
        transform.forward = Vector3.Lerp(transform.forward, jumpPos.forward, Time.fixedDeltaTime * smooth);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.T))
        {   
            setCameraPositionFrontView();
        }
        else if (Input.GetKey(KeyCode.Y))
        {   
            setCameraPositionJumpView();
        }
        else
        {
            //setCameraPositionNormalView();
        }

    }

}
