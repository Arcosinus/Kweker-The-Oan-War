using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject arene;
    public GameObject vision;
    int wait;
    bool alert;
    bool typeAtt;
    Color change;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if(player.GetComponent<Player>().vuln){
                if(typeAtt)
                {
                    player.GetComponent<Player>().takeDamage(2);
                }
                else 
                {
                    alert = true;
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        change = vision.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(alert){
            Vector3 repouss = (arene.transform.position - player.transform.position) * 0.1f;
            player.transform.Translate(repouss.normalized,Space.World);
            if (Vector3.Distance(arene.transform.position,player.transform.position) < 0.5f)
            {
                alert = false;
            }
        }
        if(Vector3.Distance(transform.position,player.transform.position) < 10)
        {
            GetComponent<Animator>().SetBool("Detected", true);
            int i = 0;
            while(i<10)
            {
                i++;
                change.a += 0.1f;
                vision.GetComponent<SpriteRenderer>().color = change;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Detected", false);
            int i = 0;
            while(i<10)
            {
                i++;
                change.a -= 0.1f;
                vision.GetComponent<SpriteRenderer>().color = change;
            }
        }
    }
}
