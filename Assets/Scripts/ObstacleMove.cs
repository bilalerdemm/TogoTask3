using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float distanceToCover;
    public float speed;

    private Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;   
    }


    void Update()
    {
        Vector3 v = startingPosition;
        v.x += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
