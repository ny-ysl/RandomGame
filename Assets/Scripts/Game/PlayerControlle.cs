using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    public int moveSpeed = 18;
    public GameConfig config;
    public GameObject point;  //提示粒子

    private Rigidbody rb;
    private GameObject cameraObject;
    private Animator anim;
    private int jumpPower = 3000;
    private float timer = 0;
    private Transform player;
    private Vector3 offsetPosition; // 相机与对象的位置偏移
    private float totaldis = 144f;

    //废弃
    private Vector3 velocity;
    private CapsuleCollider col;
    private float orgColHight;
    private Vector3 orgVectColCenter;
    private AnimatorStateInfo currentBaseState;
    //
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraObject = GameObject.FindWithTag("MainCamera");
        anim = GetComponent<Animator>();
        offsetPosition = cameraObject.transform.position - rb.transform.position;

        col = GetComponent<CapsuleCollider>();
        orgColHight = col.height;
        orgVectColCenter = col.center;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "start")
        {
            config.StarNum += 1;
            Debug.Log("吃星星");
        }

        if (collision.collider.tag == "tiaoyue")
        {
            Debug.LogError("tiaoyue");
            anim.SetBool("Jump", true);
            rb.AddForce(Vector3.up * jumpPower);
        }

        if (collision.collider.tag == "zhangaiwu")
        {
            GameOver();
        }

        if (collision.collider.tag == "diban")
        {
            anim.SetBool("Jump", false);
        }
    }

    private void GameVictory()
    {
        config.Start = false;
        config.SetResult(1);
        Debug.LogError("胜利");
    }

    private void GameOver()
    {
        config.Start = false;
        config.SetResult(2);
        Debug.LogError("失败");
    }

    public void ReSet()
    {
        timer = 0;
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{

        // anim.Play("run");
        //start = true;
        //anim.Play("jump");
        //rb.AddForce(Vector3.up * 25);
        //rb.transform.Translate(Vector3.up * 5 * Time.deltaTime);
        //Vector3 targetCampos = rb.transform.position + offsetPosition;
        //cameraObject.transform.position = Vector3.Lerp(rb.transform.position, targetCampos, 2 * Time.deltaTime);
        //cameraObject.transform.Translate(Vector3.up * 5 * Time.deltaTime);
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //}
        if (config.Start)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                rb.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                cameraObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                rb.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                cameraObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
        
    }

    void FixedUpdate()
    {
        anim.SetBool("Start", config.Start);
        if (config.Start)
        {
            point.transform.position += transform.forward * Time.deltaTime * moveSpeed * 3;
            rb.transform.position += transform.forward * Time.deltaTime * moveSpeed * 3;
            cameraObject.transform.position = offsetPosition + rb.transform.position;
        }

        if (rb.transform.position.z >= totaldis)
        {
            config.Start = false;
            timer += Time.deltaTime;
            if (timer >=2 && config.Result == 0)
            {
                GameVictory();
            }
        }

        if (rb.transform.position.y < -10)
        {
            config.Start = false;
            timer += Time.deltaTime;
            if (timer >= 2 && config.Result == 0)
            {
                GameOver();
            }
        }
    }

    /*
     *  //currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        //Debug.Log(currentBaseState.nameHash);
    float h = Input.GetAxis("Horizontal");  
    float v = Input.GetAxis("Vertical");
    static int idleState = Animator.StringToHash("Base Layer.Idle");
    if (v < -0.1)
    {
        Debug.LogError("禁止向后移动");
    }
    else
    {
        velocity = new Vector3(h, 0, v);
        velocity = transform.TransformDirection(velocity);
        velocity *= moveSpeed;
        rb.transform.localPosition += velocity * Time.fixedDeltaTime;
        cameraObject.transform.localPosition += velocity * Time.fixedDeltaTime;
    }
    */
}




