using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    public float movement;
    public float Lifetime;
    public Sprite fin;
    void OnTriggerEnter2D(Collider2D collision){
    Debug.Log(collision.name);
        Adversary enemy = collision.GetComponent<Adversary>();
        if (movement != 0 && enemy){
            Destroy(gameObject);
        }
        // if(collision.CompareTag=="Punch")
        // {
        //     !Destroy(gameObject);
        // }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (movement != 0){
            transform.Translate(movement,0,0);
            // Destroy(gameObject);
        }
    }
}
