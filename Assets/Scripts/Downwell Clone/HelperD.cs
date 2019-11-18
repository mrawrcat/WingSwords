using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperD : MonoBehaviour
{
    public GameObject finishedPanel, gameOverPanel;
    public float speedRun;
    public bool speedRunning;
    public Text speedRunTxt, health;
    
    void Update()
    {
        speedRunTxt.text = "Time: " + speedRun;
        health.text = "Health: " + GameManagerD.managerD.health + "/3";
        if (speedRunning)
        {
            speedRun += Time.deltaTime;
        }

        if(GameManagerD.managerD.gameOver == true)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
    }
}
