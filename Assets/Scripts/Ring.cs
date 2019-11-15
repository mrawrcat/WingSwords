using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    //public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameManager.manager.ringTimer > 0 && !GameManager.manager.dead)
        {
            GameManager.manager.tilespeed = 20;
        }
        else
        {
            if(GameManager.manager.tilespeed > 5 && !GameManager.manager.dead)
            {
                GameManager.manager.tilespeed -= Time.deltaTime * 1f;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.manager.score++;
            GameManager.manager.ringTimer = 5f;
        }
    }
}
