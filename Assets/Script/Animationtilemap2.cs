using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Animationtilemap2 : MonoBehaviour
{
    public GameObject P2;
    bool prop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Tilemap>().color.g >= 255)
        {
            GetComponent<Tilemap>().color = Color.blue;
            if (P2)
            {
                P2.GetComponent<Tilemap>().color = Color.blue;
            }
        } 
        else
        {
            GetComponent<Tilemap>().color = new Vector4(0,255,255,255);
            if (P2)
            {
                P2.GetComponent<Tilemap>().color = new Vector4(0,255,255,255);
            }
        }
    }
}
