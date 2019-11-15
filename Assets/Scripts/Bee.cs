using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public Transform beeStartPoint;
    public bool isPassedPoint;
    // Start is called before the first frame update
    void Start()
    {
        
        if (isPassedPoint)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 0);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.manager.beespeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPassedPoint)
        {
            transform.Translate(Vector2.left * Time.deltaTime * 0);
            transform.position = beeStartPoint.transform.position;
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.manager.beespeed);
        }

        if (transform.position.x < beeStartPoint.transform.position.x - 40)
        {
            transform.position = beeStartPoint.transform.position;
        }
        if(transform.position.x > beeStartPoint.transform.position.x)
        {
            transform.position = beeStartPoint.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.manager.dead = true;
        }
    }
}
