using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Secret: MonoBehaviour
{
    public GameObject back;
    Color init = Color.white;
    Color backC = Color.white;
    bool enter;
    bool backB;
    int i = 0;
    int j = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            enter = true;
            if (back)
            {
                backB = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            enter = false;
            if (back)
            {
                backB = false;
            }
        }
        if (GetComponent<Collider2D>().enabled == false)
        {
            enter = true;
            backB = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            if (i < 10)
            {
                i++;
                init.a -= 0.1f;
                GetComponent<Tilemap>().color = init;
            }
        }
        else
        {
            if (i > 0)
            {
                i--;
                init.a += 0.1f;
                GetComponent<Tilemap>().color = init;
            }
        }
        if (back)
        {
            if (backB)
            {
                if (j > 0)
                {
                    j--;
                    backC.a += 0.1f;
                    back.GetComponent<Tilemap>().color = backC;
                }
            }
            else
            {
                if (j < 10)
                {
                    j++;
                    backC.a -= 0.1f;
                    back.GetComponent<Tilemap>().color = backC;
                }
            }
        }
    }
}
