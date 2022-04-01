using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss1 : MonoBehaviour
{
    public float distanceToTarget;
    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;
    public GameObject projectile;
    public float powerLaser;
    private bool right;
    public Transform target;
    public Transform raycastPoint;

    public int sante;
    bool depl;
    // int dest = 0;
    bool change = false;
    bool gauched = false;
    int temps = 0;
    public float vitmov;
    public Player play;
    public Transform gauche;
    public Transform droite;
    public Transform fin;
    public GameObject santeHUD;
    public AudioSource ost;
    public AudioSource ambiance;
    bool saut;
    int serie;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && sante > 0)
        {
            play.takeDamage(4);
        }
        if (collision.transform.CompareTag("Level"))
        {
            saut = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AttackPlayer"))
        {
            sante -= 1;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    void Update()
    {
      distanceToTarget = Vector3.Distance(transform.position, target.position);

        GetComponent<SpriteRenderer>().color = Color.white;
        if (sante >=0)
        {
            depl = false;
            santeHUD.GetComponent<TextMeshPro>().text = "sante : " + sante;
            if (serie == 3)
            {
                change = true;
                serie = 0;
            }
            if (sante > 30){
                if (change && !saut)
                {
                    depl = true;
                    if (gauched)
                    {
                        Vector3 dir = droite.transform.position - transform.position;
                        transform.Translate(dir.normalized*vitmov,Space.World);
                    }
                    else
                    {
                        Vector3 dir = gauche.transform.position - transform.position;
                        transform.Translate(dir.normalized*vitmov,Space.World);
                    }
                }
            }
            else
            {
                if (change)
                {
                    depl = true;
                    if (gauched)
                    {
                        Vector3 dir = droite.transform.position - transform.position;
                        transform.Translate(dir.normalized*vitmov,Space.World);
                    }
                    else
                    {
                        Vector3 dir = gauche.transform.position - transform.position;
                        transform.Translate(dir.normalized*vitmov,Space.World);
                    }
                }
            }
            if (!saut && !change)
            {
                if (temps >= 25)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0,500f));
                    saut = true;
                    serie++;
                    temps = 0;
                }
                temps++;
            }

            // Quaternion newRotation;

            if (gauched)
            {
                if (Vector3.Distance(transform.position,droite.transform.position) < 0.5f)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    gauched = false;
                    change = false;
                    // newRotation = Quaternion.Euler (0f, 0f, 0f);
                    // transform.rotation = newRotation;
                    // transform.Translate(-transform.right * Time.deltaTime * vitmov,Space.Self);
                    // right = true;

                }
            }
            else
            {
                if (Vector3.Distance(transform.position,gauche.transform.position) < 0.5f)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                    gauched = true;
                    change = false;
                    // newRotation = Quaternion.Euler (0f, 180f, 0f);
                    // transform.rotation = newRotation;
                    // transform.Translate(transform.right * Time.deltaTime * vitmov,Space.Self);
                    // right = false;

                }
            }

            GetComponent<Animator>().SetBool("Saut", saut);
            GetComponent<Animator>().SetBool("Mouve", depl);
        } else {
            ost.Stop();
            ambiance.Play();
            GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        if (transform.position.y <= 16){
            santeHUD.transform.position = new Vector3(santeHUD.transform.position.x,santeHUD.transform.position.y,-6);
            fin.position = new Vector3(fin.position.x,fin.position.y,-4);
            Destroy(gameObject);
        }

        if(distanceToTarget > attackRange)
        {
          Attack();
        }
    }

    void Attack()
    {
      Vector3 targetDir = target.position - transform.position;

      if(Time.time > lastAttackTime + attackDelay)
      {
        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, transform.right,attackRange);
        if (hit.transform == target)
        {
          GameObject newPowerLaser = Instantiate(projectile,transform.position, transform.rotation);
          // if(right)
          // {
            // newPowerLaser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-powerLaser,0f));
            newPowerLaser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(powerLaser,0f));
          // }
          // else {
          //   // newPowerLaser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(powerLaser,0f));
          //   newPowerLaser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-powerLaser,0f));
          // }
          lastAttackTime = Time.time;
        }
      }
    }
}
