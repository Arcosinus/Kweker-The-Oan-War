using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserWolf : MonoBehaviour
{
  public Rigidbody2D rb;
  public int damage;

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.transform.CompareTag ("Player"))
    {
      col.transform.SendMessage("TakeDamage", damage);
      Destroy(gameObject);
    }
  }
}
