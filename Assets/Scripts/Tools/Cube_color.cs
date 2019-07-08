using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_color : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;


    void Start()
    {
        //GameObject cube = GameObject.Find("Cube");

        if (cube != null)
        {
            Renderer render = cube.GetComponent<Renderer>();
            render.material.color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
