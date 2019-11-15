using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolNoTurn : MonoBehaviour
{
    public float speed;
    public GameObject[] patrolPoints;
    public int whichPoint;
    float distToPatrolPoint;
    //float distToPlayer;
    //public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
