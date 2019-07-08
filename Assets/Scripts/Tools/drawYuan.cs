using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawYuan : MonoBehaviour
{
    public List<Vector3> points;
    //public LineRenderer line;
    public GameObject gameob;
    float angle = 0;
    float z = -30;
    public float w = 4;
    public float h = 2;
    public float r = 1;
    public void AddPoints()
    {
        Vector3 pt = transform.position;

        if (points.Count > 0 && (pt - lastPoint).magnitude < 0.1f)
        {
            return;
        }

        points.Add(pt);
       // line.numPositions = points.Count;
        //line.SetPosition(points.Count - 1, lastPoint);
    }

    public Vector3 lastPoint
    {
        get
        {
            if (points == null)
            {
                return Vector3.zero;
            }
            return (points[points.Count - 1]);
        }
    }

    private void FixedUpdate()
    {
        angle += Time.deltaTime / 100 * 5;
        float x = r * Mathf.Cos(angle * Mathf.Rad2Deg);
        float y = r * Mathf.Sin(angle * Mathf.Rad2Deg);
        z += Time.fixedDeltaTime * 7;
        transform.position = new Vector3(x, y + (float)2.5, z);

        if (transform.position.z >= -1 && transform.position.z <= 1)
        {
            gameob.SetActive(false);
        }

        /*
         * // float x = w * Mathf.Cos(angle * Mathf.Rad2Deg);
        // float y = h * Mathf.Sin(angle * Mathf.Rad2Deg);
       if (angle < 0.15)
        {
            float x = r * Mathf.Cos(angle * Mathf.Rad2Deg );
            float y = r * Mathf.Sin(angle * Mathf.Rad2Deg);
            z += Time.fixedDeltaTime * 5;
            transform.position = new Vector3(x, y + (float)2.5, z);
            //transform.position = new Vector3(x, y + (float)2.5, -30);
            //AddPoints();
       }
        if(angle > 0.15){
           transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y + 2, 0), Time.fixedDeltaTime * 1);
        }
        */
    }
}
