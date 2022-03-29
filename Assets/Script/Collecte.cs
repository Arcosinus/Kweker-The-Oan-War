using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecte : MonoBehaviour
{
    public string objet;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            collision.GetComponent<Player>().W2 = objet;
            Destroy(gameObject);
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
