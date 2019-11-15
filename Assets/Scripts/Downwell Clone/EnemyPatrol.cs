using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float movespeed;
    public GameObject[] points;
    int nextPoint = 1;
    float distToPoint;
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, points[nextPoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, points[nextPoint].transform.position, movespeed * Time.deltaTime);

        if(distToPoint < 0.02f)
        {
            Turn();
        }
    }

    void Turn()
    {
        Vector3 currentRot = transform.eulerAngles;
        currentRot.z += points[nextPoint].transform.eulerAngles.z;
        transform.eulerAngles = currentRot;
        nextPoint++;

        if(nextPoint == points.Length)
        {
            nextPoint = 0;
        }
    }
}
