using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float distanceToCover;
    public float speed;
    public bool isHorizontal = false, isVertical = false;

    private Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;   
    }


    void Update()
    {
        if (isVertical)
        {
            Vector3 v = startingPosition;
            v.x += distanceToCover * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }
        if (isHorizontal)
        {
            Vector3 v = startingPosition;
            v.z += distanceToCover * Mathf.Sin(Time.time * speed);
            transform.position = v;
        }

    }
}
