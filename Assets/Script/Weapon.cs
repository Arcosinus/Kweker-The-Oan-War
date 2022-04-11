using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Data").GetComponent<DataStorage>().W2 == "Napalm")
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
