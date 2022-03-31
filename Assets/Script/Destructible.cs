using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructible : MonoBehaviour
{
    public bool napalm;
    public GameObject[] deco;
    bool burn = false;
    int b = 0;
    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (napalm){
            if (collision.transform.CompareTag("TirNapalm")&&!burn)
            {
                GetComponent<Tilemap>().color = Color.red;
                if (deco[0])
                {
                    int i = 0;
                    while (i != deco.Length)
                    {
                        deco[i].GetComponent<Temporary>().enabled = true;
                        deco[i].GetComponent<SpriteRenderer>().color = Color.white;
                        i++;
                    }
                }
                burn = true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (burn)
        {
            b++;
            if(b >= 100)
            {
                Destroy(gameObject);
            }
        }
    }
}
