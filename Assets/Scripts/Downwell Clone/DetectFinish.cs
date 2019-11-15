using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFinish : MonoBehaviour
{
    public HelperD helper;

    private void Start()
    {
        helper = FindObjectOfType<HelperD>();
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            Debug.Log("Finished Level");
            helper.speedRunning = false;
            helper.finishedPanel.SetActive(true);
        }
    }
}
