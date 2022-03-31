using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    public float movement;
    public float Lifetime;
    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (movement != 0 && !collision.transform.CompareTag("AttackPlayer") && !collision.transform.CompareTag("TirNapalm") && !collision.transform.CompareTag("SafeTir") && !collision.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,Lifetime);
        if (GetComponent<Rigidbody2D>())
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            if(transform.name == "Napalm(Clone)")
            {
                GetComponent<Rigidbody2D>().gravityScale = -1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movement != 0)
        {
            transform.Translate(movement,0,0);
        }
    }
}
