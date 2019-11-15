using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperD : MonoBehaviour
{
    public GameObject finishedPanel;
    public float speedRun;
    public bool speedRunning;
    public Text speedRunTxt;
    
    void Update()
    {
        speedRunTxt.text = "Time: " + speedRun;
        if (speedRunning)
        {
            speedRun += Time.deltaTime;
        }
    }
}
