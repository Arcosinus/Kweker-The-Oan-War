using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float OrigineY = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S)&&OrigineY>-0.5f)
        {
            transform.Translate(0,-0.05f,0);
            OrigineY -= 0.05f;
        }
        else if (OrigineY < 0.5f && !(Input.GetKey(KeyCode.S)))
        {
            transform.Translate(0,0.05f,0);
            OrigineY += 0.05f;
        }
        if (Input.GetKey(KeyCode.Z)&&OrigineY<1.5f)
        {
            transform.Translate(0,0.05f,0);
            OrigineY += 0.05f;
        }
        else if (OrigineY > 0.5f && !(Input.GetKey(KeyCode.Z)))
        {
            transform.Translate(0,-0.05f,0);
            OrigineY -= 0.05f;
        }
    }
}
