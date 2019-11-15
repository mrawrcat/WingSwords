using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed, savedspeed;
    public GameObject[] patrolPoints;
    public int whichPoint;
    float distToPatrolPoint;
    float distToPlayer;

    //public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 0;
        savedspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(whichPoint == 1)
        {
            speed = savedspeed *2;
        }
        else
        {
            speed = savedspeed;
        }
        //this transforms the object. input player pos if want to transform player
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime * speed);

            distToPatrolPoint = Vector3.Distance(transform.position, patrolPoints[whichPoint].transform.position);

            if (distToPatrolPoint < 0.02f)
            {
                whichPoint++;
                if (whichPoint >= patrolPoints.Length)
                {
                    whichPoint = 0;
                }

                Vector3 scaler = transform.localScale;
                scaler.x *= -1;
                transform.localScale = scaler;
            }
        
    }
}
