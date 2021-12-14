using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,0f);
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0,0.03f,0);
        } 
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0,0,5);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,0,-5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.02f,0,0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-0.02f,0,0);
        }
    }
}
