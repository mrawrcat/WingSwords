using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    //the player's speed when going up and down
    public float upspeed, downspeed;
    public float health, speed, jumpforce;
    public float tilespeed, beespeed, topBarrier, botBarrier, score, highscore;

    public float ringTimer;
    public bool dead, invincible;

    private string key = "highscore";
    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
        

    }
    private void Update()
    {
        ringTimer -= Time.deltaTime;

        if (score > highscore)
        {
            highscore = score;
        }

        if (dead)
        {
            tilespeed = 0;
            botBarrier = -10f;
            ringTimer = -1;
            if (score > highscore)
            {
                PlayerPrefs.SetFloat(key, score);
               
            }
        }

        if (!dead)
        {
            botBarrier = -3.3f;
            if(ringTimer <= 0)
            {
                tilespeed = 5f;
            }
        }
    }

    


}
