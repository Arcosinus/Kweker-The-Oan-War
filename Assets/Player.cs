using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float VectorX = 0f;
    float VectorY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(VectorX,VectorY,0);
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
        if (Input.GetKeyPress(KeyCode.D))
        {
            VectorX = VectorX + 0.2f;
        }
        if (Input.GetKeyPress(KeyCode.Q))
        {
            VectorX = VectorX - 0.2f;
        }
        if (Input.GetKeyPress(KeyCode.Z))
        {
            for (int i = 0; i < 10; i++)
            {
                transform.Translate(0,0.1f,0);
            }
        }
        if (VectorX < 0f)
        {
            VectorX = VectorX + 0.1f;
        }
        if (VectorX > 0f)
        {
            VectorX = VectorX - 0.1f;
        }
    }
}
