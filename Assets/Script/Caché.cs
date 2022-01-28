using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caché : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.CompareTag("Player")){
            transform.position = new Vector3(0,0,-6);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        transform.position = new Vector3(0,0,-4);
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
