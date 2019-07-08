using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    private Transform player;
    private float rotateSpeed = 2; // 旋转速度

    private void Start()
    {
        player = rb.transform; // 获取跟随物体的位置
    }

    private void Update()
    {
        //Quaternion qua = Quaternion.LookRotation(new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical));
        //rb.transform.rotation = qua;
        //rb.transform.LookAt(new Vector3(rb.transform.position.x + variableJoystick.Horizontal, rb.transform.position.y, rb.transform.position.z + variableJoystick.Vertical));

        RotateView();
    }
    void RotateView()
    {
        if ( Input.GetKey(KeyCode.Q))
        {
            rb.transform.RotateAround(player.position, Vector3.up, -rotateSpeed);
        }
        else if ( Input.GetKey(KeyCode.E))
        {
            rb.transform.RotateAround(player.position, Vector3.up, rotateSpeed);
        }
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward  * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        Vector3 movingDirection = transform.rotation * direction;
        rb.AddForce(movingDirection * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        if (variableJoystick.Vertical != 0)
        {
            Debug.Log(variableJoystick.Vertical);
            Debug.Log(variableJoystick.Horizontal);
        }
        

        //Quaternion rotation = rb.rotation;
        //right x  up y  forward z 

        //direction = direction * dir;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}