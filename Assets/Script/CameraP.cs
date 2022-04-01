using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraP : MonoBehaviour
{
    public bool finintro = true;
    public GameObject[] Script;
    public GameObject Player;
    public Transform inter;
    public Transform player;

    float OrigineY = 0.5f;
    float OrigineX = 0;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 57.5f && !finintro)
        {
            transform.Translate(0,-0.5f,0);
            transform.position = new Vector3(player.position.x,transform.position.y,-5);
        }
        if (transform.position.y <= player.position.y+2 && !finintro)
        {
            finintro = true;
            transform.position = new Vector3(player.position.x,player.position.y+2,-5);
            int i = 0;
            while (i != Script.Length)
            {
                Script[i].GetComponent<Adversary>().enabled = true;
                i++;
            }
            Player.GetComponent<Player>().enabled = true;
            inter.position = new Vector3(inter.position.x,inter.position.y,-3);
        }
        if (Input.GetKey(KeyCode.DownArrow) && !(Input.GetKey(KeyCode.UpArrow)) &&transform.position.y > Player.transform.position.y - 1)
        {
            transform.Translate(0,-0.02f,0);
        }
        else if (transform.position.y < Player.transform.position.y + 1 && !(Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.UpArrow)))
        {
            transform.Translate(0,0.02f,0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && !(Input.GetKey(KeyCode.DownArrow)) && transform.position.y < Player.transform.position.y + 3)
        {
            transform.Translate(0,0.02f,0);
        }
        else if (transform.position.y > Player.transform.position.y + 1 && !(Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.UpArrow)))
        {
            transform.Translate(0,-0.02f,0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && !(Input.GetKey(KeyCode.LeftArrow)) &&transform.position.x < Player.transform.position.x + 3)
        {
            transform.Translate(0.02f,0,0);
        }
        else if (transform.position.x > Player.transform.position.x && !(Input.GetKey(KeyCode.RightArrow)) && !(Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Translate(-0.02f,0,0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !(Input.GetKey(KeyCode.RightArrow)) &&transform.position.x > Player.transform.position.x - 3)
        {
            transform.Translate(-0.02f,0,0);
        }
        else if (transform.position.x < Player.transform.position.x && !(Input.GetKey(KeyCode.RightArrow)) && !(Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Translate(0.02f,0,0);
        }
    }
}
