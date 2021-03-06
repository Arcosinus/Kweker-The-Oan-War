using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adversary : MonoBehaviour
{
    public int sante;
    public bool Napalm;
    bool burn;
    int burncount;
    int dest = 0;
    public float vitmov;
    public Transform pos;
    public Player play;
    public Transform[] waypoint;
    public Transform target;
    public GameObject drops;
    public GameObject dropm;
    bool drop = true;
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player") && sante > 0)
        {
            play.takeDamage(2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.CompareTag("TirNapalm")&&Napalm)
        {
            burn = true;
            burncount = 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (sante >=0){
            if (burn){
                if (Color.white == GetComponent<SpriteRenderer>().color)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                } 
                else 
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                }
                burncount++;
                if (burncount/100 == 1)
                {
                    sante-=1;
                }
                if (burncount/100 == 2)
                {
                    sante-=1;
                }
                if (burncount/100 == 3)
                {
                    sante-=1;
                    burn = false;
                    burncount = 0;
                }
            }
            Vector3 dir = target.transform.position - transform.position;
            transform.Translate(dir.normalized*vitmov,Space.World);
            if (Vector3.Distance(transform.position,target.transform.position) < 0.5f){
                target = waypoint[dest];
                if (dest == waypoint.Length-1){
                    dest = 0;
                } else {
                    dest++;
                }
            }
            if (target.transform.position.x < transform.position.x){
                GetComponent<SpriteRenderer>().flipX = false;
            } else {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        } else {
            if(drop && play.W2 == "Napalm"){ 
                if (play.munitionDispo == 3)
                {
                    GameObject soin;
                    soin = Instantiate(drops);
                    soin.transform.position = transform.position;
                    drop = false;
                }
                else
                {
                    GameObject munit;
                    munit = Instantiate(dropm);
                    munit.transform.position = transform.position;
                    drop = false;
                }
            }
            else if (drop)
            {
                GameObject soin;
                soin = Instantiate(drops);
                soin.transform.position = transform.position;
                drop = false;
            }
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        if (transform.position.y <= 16){
            Destroy(gameObject);
        }
    }
}
