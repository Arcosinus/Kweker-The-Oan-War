using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public int prog = 1;
    public int lvl = 0;
    public double inspect = 0;
    public GameObject Arxcoz;
    public GameObject[] niveau;
    public GameObject[] carte;
    // Start is called before the first frame update
    void Start()
    {
        Arxcoz.transform.position = niveau[lvl].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (prog == 2)
        {
            carte[0].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[1].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,0);
        } 
        else if (prog > 10)
        {
            carte[0].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[1].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[2].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[3].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[4].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[5].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[6].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[7].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,0);
        }
        else if (prog > 9)
        {
            carte[0].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[1].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[2].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[3].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[4].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[5].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[6].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,0);
        }
        else if (prog > 8)
        {
            carte[0].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[1].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[2].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[3].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[4].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[5].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,0);
        }
        else if (prog > 7)
        {
            carte[0].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[1].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[2].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[3].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[4].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,0);
        }
        else if (prog > 6 && inspect == 1)
        {
            carte[0].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[1].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[2].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[3].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,0);
        }
        else if (prog > 4)
        {
            carte[0].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[1].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
            carte[2].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,0);
        }
        else if (prog > 2)
        {
            carte[0].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,0);
            carte[1].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,1);
        } 
        
        
        /*else
        {
            carte[0].transform.position = new Vector3(carte[0].transform.position.x,carte[0].transform.position.y,0);
            carte[1].transform.position = new Vector3(carte[1].transform.position.x,carte[1].transform.position.y,1); 
            carte[2].transform.position = new Vector3(carte[2].transform.position.x,carte[2].transform.position.y,1); 
            carte[3].transform.position = new Vector3(carte[3].transform.position.x,carte[3].transform.position.y,1); 
            carte[4].transform.position = new Vector3(carte[4].transform.position.x,carte[4].transform.position.y,1); 
            carte[5].transform.position = new Vector3(carte[5].transform.position.x,carte[5].transform.position.y,1); 
            carte[6].transform.position = new Vector3(carte[6].transform.position.x,carte[6].transform.position.y,1); 
            carte[7].transform.position = new Vector3(carte[7].transform.position.x,carte[7].transform.position.y,1); 
        }*/
        if (prog < 7)
        {
            int i = 0;
            while(i < prog)
            {
                niveau[i].GetComponent<SpriteRenderer>().color = Color.green;
                i++;
            }
            niveau[i].GetComponent<SpriteRenderer>().color = Color.red;
            i++;
            while(i < niveau.Length)
            {
                niveau[i].GetComponent<SpriteRenderer>().color = Color.grey;
                i++;
            }
        }
        if (prog == 7)
        {
            int i = 0;
            while(i < prog)
            {
                niveau[i].GetComponent<SpriteRenderer>().color = Color.green;
                i++;
            }
            niveau[i].GetComponent<SpriteRenderer>().color = Color.red;
            i++;
            niveau[i].GetComponent<SpriteRenderer>().color = Color.red;
            i++;
            niveau[i].GetComponent<SpriteRenderer>().color = Color.red;
            i++;
            while(i < niveau.Length)
            {
                niveau[i].GetComponent<SpriteRenderer>().color = Color.grey;
                i++;
            }
        }
        if (prog > 7)
        {
            int i = 0;
            while(i < prog+2)
            {
                niveau[i].GetComponent<SpriteRenderer>().color = Color.green;
                i++;
            }
            niveau[i].GetComponent<SpriteRenderer>().color = Color.red;
            i++;
            while(i < niveau.Length)
            {
                niveau[i].GetComponent<SpriteRenderer>().color = Color.grey;
                i++;
            }
        }
    }
}
