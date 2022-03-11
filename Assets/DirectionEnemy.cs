using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionEnemy : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 direction;
    private float angle;

    void FacePlayersDirection()
    {
        direction = playerTransform.position - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
    }
    private void Awake()
    {
      playerTransform = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        FacePlayersDirection();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

}
