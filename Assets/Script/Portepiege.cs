using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portepiege : MonoBehaviour
{
    public bool capt = false;
    public void Setcapt(bool val){
        capt = val;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 0 && capt == false)
        {
            transform.Translate(new Vector3(-0.1f,0,0));
        }
        if(transform.position.x <= 2.9f && capt)
        {
            transform.Translate(new Vector3(0.1f,0,0));
        }
    }
}
