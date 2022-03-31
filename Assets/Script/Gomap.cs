using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gomap : MonoBehaviour
{
    public int level;
    public void GetLevel()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player")){
            if(GameObject.Find("Data"))
            {
                GameObject.Find("Data").GetComponent<DataStorage>().GetData();
                GameObject.Find("Data").GetComponent<DataStorage>().SetLevel(level);
                GameObject.Find("Data").GetComponent<DataStorage>().Save();
            }
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
