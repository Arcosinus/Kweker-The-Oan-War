using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adversary : MonoBehaviour
{

    public int sante;
    //float PositionMove = 0;
    int dest = 0;
    public float vitmov;
    public Transform pos;
    public Player play;
    public Transform[] waypoint;
    public Transform target;
    private Transform playerTransform;
    private Vector3 direction;
    private float angle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.transform.CompareTag("Player") && sante > 0)
      {
        play.takeDamage(2);
      }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.CompareTag("AttackPlayer"))
      {
          sante -= 1;
          Destroy(gameObject);
      }
    }
    void directionAttack()
    {
      direction = playerTransform.position - transform.position;
      angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
      playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame

    void Update()
    {
      if (sante >= 0)
      {
        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized*vitmov,Space.World);
        if (Vector3.Distance(transform.position,target.transform.position) < 0.5f)
        {
            target = waypoint[dest];
            if (dest == waypoint.Length-1)
            {
                dest = 0;
            } else
            {
                dest++;
            }
        }
        if (target.transform.position.x < transform.position.x){
            GetComponent<SpriteRenderer>().flipX = false;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
      }
      else
      {
          GetComponent<SpriteRenderer>().color = Color.red;
          GetComponent<Collider2D>().isTrigger = true;
          GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
      }
      if (transform.position.y <= 16)
      {
          Destroy(gameObject);
      }
    }
}
