using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adversary : MonoBehaviour
{
    public int sante;
    // float PositionMove = 0;
    // int dest = 0;
    public float vitmov;
    public Transform pos;
    public Player play;
    public Transform[] waypoint;
    // public Transform target;
    Transform currentWp;
    int currentWpIndex;

    public Transform target;
    public float chaseRange;

    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    public GameObject projectile;
    public float powerLaser;

    public float checkRange;
    public float distanceToTarget;
    public Transform raycastPoint;
    private bool right;

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.CompareTag("Player") && sante > 0){
            play.takeDamage(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.transform.CompareTag("AttackPlayer"))
        {
            sante -= 1;
        }
    }

    void Start()
    {
      currentWpIndex= 0;
      currentWp = waypoint[currentWpIndex];
    }

    void Update()
    {
      distanceToTarget = Vector3.Distance(transform.position, target.position);
      if(distanceToTarget > checkRange)
      {
        Waypoint();
      }
      // if(distanceToTarget < checkRange && distanceToTarget > attackRange)
      // {
      //   Chase();
      // }
      if(distanceToTarget < attackRange)
      {
        Attack();
      }
    }
    // void Chase()
    // {
    //   Vector3 targetDir = target.position - transform.position;
    //   float angle = Mathf.Atan2 (targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
    //   Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
    //   transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 180);
    //
    //   transform.Translate (Vector3.up * Time.deltaTime * vitmov);
    // }
    void Attack()
    {
      Vector3 targetDir = target.position - transform.position;

      if(Time.time > lastAttackTime + attackDelay)
      {
        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, transform.right,attackRange);
        if (hit.transform == target)
        {
        GameObject newPowerLaser = Instantiate(projectile,transform.position, transform.rotation);
        if(right)
        {
          newPowerLaser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-powerLaser,0f));
          // newPowerLaser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(powerLaser,0f));
        }
        else {
          newPowerLaser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(powerLaser,0f));
          // newPowerLaser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-powerLaser,0f));
        }
        lastAttackTime = Time.time;
        }
      }
    }

    void Waypoint()
    {
      if (sante > 0)
      {
        if (Vector3.Distance (transform.position, currentWp.position) < 0.5f)
        {
          if (currentWpIndex + 1 < waypoint.Length)
            currentWpIndex++;
          else
            currentWpIndex = 0;

          currentWp = waypoint[currentWpIndex];
        }
        Quaternion newRotation;

        Vector3 waypointDir = currentWp.position - transform.position;
        if(waypointDir.x < 0f)
        {
          newRotation = Quaternion.Euler (0f, 0f, 0f);
          transform.rotation = newRotation;
          transform.Translate(-transform.right * Time.deltaTime * vitmov,Space.Self);
          right = false;
        }
        if(waypointDir.x > 0f)
        {
          newRotation = Quaternion.Euler (0f, 180f, 0f);
          transform.rotation = newRotation;
          transform.Translate(transform.right * Time.deltaTime * vitmov,Space.Self);
          right = true;

        }
        if (transform.position.y <= 16)
        {
            Destroy(gameObject);
        }
      }
      else
      {
          GetComponent<SpriteRenderer>().color = Color.red;
          GetComponent<Collider>().isTrigger = true;
          GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
      }
    }
}
