using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera : MonoBehaviour
{
    public float scrollSpeed = 3; // 拉进/拉远视角的速度
    public float rotateSpeed = 2; // 旋转速度
    public Rigidbody rb;
    
    private Vector3 offsetPosition; // 相机与对象的位置偏移
    
    private int moveSpeed = 1;
    private Transform player;
    private bool isRotating = false; // 是否旋转
    private float distance = 0;

    private float h;
    private float v;
    private Vector3 dir;

    void Start()
    {
        player = rb.transform; // 获取跟随物体的位置
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
    }

    void Update()
    {
        /*
        //四个方向
        if (Input.GetKey(KeyCode.W))
        {
            DragGameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
           transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            DragGameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            DragGameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            DragGameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            DragGameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            DragGameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            DragGameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            DragGameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        */

        //Vector3 direction = rb.transform.localPosition;

        //Vector3 player_postion = Player.transform.position;
        // float x = player_postion.x;
        //float y = player_postion.y;
        // float z = player_postion.z;


        //A点到B点移动的两种方法：MoveTowards和Lerp
        /*if (Input.GetKey(KeyCode.W))
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, stmp);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = Vector3.Lerp(transform.position, target.position, stmp);
            }*/
        //direction.Set(direction.x, direction.y + 2, direction.z - 10);

        //Debug.Log(direction.x);
        //Debug.Log(direction.y);
        //Debug.Log(direction.z);
        //transform.TransformVector(direction);
        //transform.Translate(direction);

        //velocity = new Vector3(0, 0, v);      //转向
       // velocity = transform.TransformDirection(velocity);

        transform.position = offsetPosition + player.position;
        RotateView(); // 处理视野的旋转
        ScrollView(); // 处理视野的拉近和拉远效果  
    }

    void RotateView()
    {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }

        if (isRotating && Input.GetKey(KeyCode.Q))
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            dir = new Vector3(h, 0, v);

            //rb.transform.RotateAround(player.position, Vector3.up, -rotateSpeed);
            transform.RotateAround(player.position, Vector3.up, -rotateSpeed);
        }
        else if (isRotating && Input.GetKey(KeyCode.E))
        {
            //rb.transform.RotateAround(player.position, Vector3.up, rotateSpeed);
            transform.RotateAround(player.position, Vector3.up, rotateSpeed);
        }

        offsetPosition = transform.position - player.position;
    }


    void ScrollView()
    {
        // 向后滑动返回负值（拉远视野） 向前滑动返回正值（拉近视野）
        distance = offsetPosition.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        distance = Mathf.Clamp(distance, 5, 10);
        offsetPosition = offsetPosition.normalized * distance;
    }
}
