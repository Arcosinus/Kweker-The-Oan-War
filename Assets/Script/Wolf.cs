using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    float PositionMove = 0;
    bool DirectionLeft = false;
    public Animator ame;
    public Transform pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ame.SetBool("Direction", DirectionLeft);
        if ((PositionMove < 3)&&!(DirectionLeft))
        {
            transform.Translate(0.01f,0,0);
            PositionMove += 0.01f;
        }
        if (PositionMove > 3)
        {
            DirectionLeft = true;
        }
        if ((PositionMove > 0)&&(DirectionLeft))
        {
            transform.Translate(-0.01f,0,0);
            PositionMove -= 0.01f;
        }
        if ((PositionMove < 0))
        {
            DirectionLeft = false;
        }
    }
}
