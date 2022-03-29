using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public bool napalm;
    public GameObject[] deco;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (napalm){
            if (collision.transform.CompareTag("TirNapalm"))
            {
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
                Destroy(gameObject);
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
    }
}
