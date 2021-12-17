using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int sante = 16;
    public Rigidbody2D rb;
    public Animator ame;
    public bool saut = false;
    private Vector3 vel = Vector3.zero;
    public float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&!(saut))
        {
            rb.AddForce(new Vector2(0,300f));
        }
        float Xmov = Input.GetAxis("Horizontal") * movespeed;
        Vector3 mouv = new Vector2(Xmov, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, mouv, ref vel, 0.05f);
        ame.SetFloat("Move", Xmov);
    }
}
