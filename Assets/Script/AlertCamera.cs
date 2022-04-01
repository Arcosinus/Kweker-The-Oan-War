using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject arene;
    public GameObject vision;
    bool alert;
    bool detected;
    public bool typeAtt;
    Color change;
    int wait = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(player.GetComponent<Player>().vuln){
                if(typeAtt)
                {
                    player.GetComponent<Player>().takeDamage(2);
                    GameObject grab = Instantiate(GameObject.Find("Head"));
                    grab.name = "Head" + transform.name;
                    GameObject.Find("Head"+transform.name).transform.position = arene.transform.position;
                    GameObject.Find("Head"+transform.name).GetComponent<AnimationLiane>().enabled = true;
                }
                else 
                {
                    if (detected)
                    {
                        GameObject grab = Instantiate(GameObject.Find("Head"));
                        grab.name = "Head" + transform.name;
                        GameObject.Find("Head"+transform.name).transform.position = arene.transform.position;
                        GameObject.Find("Head"+transform.name).GetComponent<AnimationLiane>().enabled = true;
                        detected = false;
                    }
                    alert = true;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        detected = true;
        change = vision.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    async void Update()
    {
        int i = 0;
        if(alert){
            Vector3 repouss = (arene.transform.position - player.transform.position) / 10;
            player.transform.Translate(repouss,Space.World);
            if (Vector3.Distance(arene.transform.position,player.transform.position) < 0.5f)
            {
                detected = true;
                alert = false;
            }
        }
        else if(wait <= 400)
        {
            GetComponent<Animator>().SetBool("Detected", true);
            change.a = 0.5f;
            vision.GetComponent<SpriteRenderer>().color = change;
            GetComponent<PolygonCollider2D>().enabled = true;
            wait++;
        }
        else if (wait <= 800)
        {
            GetComponent<Animator>().SetBool("Detected", false);
            change.a = 0;
            vision.GetComponent<SpriteRenderer>().color = change;
            GetComponent<PolygonCollider2D>().enabled = false;
            wait++;
        }
        else
        {
            wait = 0;
        }
    }
}
