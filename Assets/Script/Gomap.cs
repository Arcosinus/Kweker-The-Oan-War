using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gomap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")){
            SceneManager.LoadScene("Map");
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
