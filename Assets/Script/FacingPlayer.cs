using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingPlayer : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 direction;
    private float angle;

    void FacePlayersDirection()
    {
      direction = playerTransform.position - transform.position;
      angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Awake()
    {
      playerTransform = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        FacePlayersDirection();
    }
}
