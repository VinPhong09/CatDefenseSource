using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
     public float speed ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //MoveCamByMouse();
        MoveCamByKey();
    }

    void MoveCamByMouse()
    {
        // Move Left
        if(Input.mousePosition.x <= 0)
        {
            if(transform.position.x <= -8f)
                transform.position = transform.position;
            else
                transform.position += new Vector3(-1 * Time.deltaTime * speed, 0);
        }
        // Move Right
        if(Input.mousePosition.x >= 1900)
            {
                if(transform.position.x >= 19f)
                    transform.position = transform.position;
                else
                    transform.position += new Vector3(1 * Time.deltaTime * speed, 0);
            }
    }
    void MoveCamByKey()
    {
        float A = Input.GetAxis("Horizontal");
        if(A< 0)
        {
            if(transform.position.x <= -8f)
                transform.position = transform.position;
            else
                transform.position += new Vector3(A * Time.deltaTime * speed, 0);
        }

        if(A> 0)
        {
            if(transform.position.x >= 19f)
                transform.position = transform.position;
            else
                transform.position += new Vector3(A * Time.deltaTime * speed, 0);
        }
    }
}
