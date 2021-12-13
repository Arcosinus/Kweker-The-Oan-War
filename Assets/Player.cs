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
        if (Input.GetKeyDown(KeyCode.I))
        {
            GetComponent<Renderer> ().material.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer> ().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(1,0,0);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Translate(-1,0,0);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            for (int i = 0; i < 10; i++)
            {
                transform.Translate(0,0.1f,0);
            }
        }
    }
}
