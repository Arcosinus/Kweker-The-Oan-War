using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float OrigineY = 0.5f;
    float OrigineX = 0;
    float OrigineZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow)&&OrigineY>-0.5f)
        {
            transform.Translate(0,-0.05f,0);
            OrigineY -= 0.05f;
        }
        else if (OrigineY < 0.5f && !(Input.GetKey(KeyCode.DownArrow)))
        {
            transform.Translate(0,0.05f,0);
            OrigineY += 0.05f;
        }
        if (Input.GetKey(KeyCode.UpArrow)&&OrigineY<1.5f)
        {
            transform.Translate(0,0.05f,0);
            OrigineY += 0.05f;
        }
        else if (OrigineY > 0.5f && !(Input.GetKey(KeyCode.UpArrow)))
        {
            transform.Translate(0,-0.05f,0);
            OrigineY -= 0.05f;
        }
        if (Input.GetKey(KeyCode.RightArrow)&&OrigineX<1.5f)
        {
            transform.Translate(0.05f,0,0);
            OrigineX += 0.05f;
        }
        else if (OrigineX > 0.5f && !(Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Translate(-0.05f,0,0);
            OrigineX -= 0.05f;
        }
        if (Input.GetKey(KeyCode.LeftArrow)&&OrigineX>-1.5f)
        {
            transform.Translate(-0.05f,0,0);
            OrigineX -= 0.05f;
        }
        else if (OrigineX < 0.5f && !(Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Translate(0.05f,0,0);
            OrigineX += 0.05f;
        }
        if (Input.GetKey(KeyCode.J)&&OrigineZ < 2)
        {
            transform.Translate(0,0,1);
            OrigineZ += 1f;
        }
        else if (OrigineZ > 0 && !(Input.GetKey(KeyCode.J)))
        {
            transform.Translate(0,0,-1);
            OrigineZ -= 1f;
        }
    }
}
