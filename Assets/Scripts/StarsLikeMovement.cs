using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsLikeMovement : MonoBehaviour
{
    
    public bool up;
    public GameObject flames, line;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.manager.tilespeed > 10)
        {
            flames.SetActive(true);
            line.SetActive(true);
        }
        else
        {
            flames.SetActive(false);
            line.SetActive(false);
        }

        if (!up)
        {
            if (transform.localPosition.y > GameManager.manager.botBarrier)
            {
                transform.Translate(Vector2.down * GameManager.manager.downspeed * Time.deltaTime);
            }
        }
        else if (GameManager.manager.dead)
        {
            if (transform.localPosition.y > GameManager.manager.botBarrier)
            {
                transform.Translate(Vector2.down * GameManager.manager.downspeed * Time.deltaTime);
            }
        }

        if (!GameManager.manager.dead)
        {
            if (up == true)
            {
                if (transform.localPosition.y < GameManager.manager.topBarrier)
                {
                    transform.Translate(Vector2.up * GameManager.manager.upspeed * Time.deltaTime);
                }
            }
        }
        

        if (Input.GetKey(KeyCode.Space))
        {
            up = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            up = false;
        }
    }
}
