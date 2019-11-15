using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public CamShake camshake;
    //public GameHelper helper;
    private void Start()
    {
        camshake = FindObjectOfType<CamShake>();
        //helper = FindObjectOfType<GameHelper>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
           camshake.shakeDuration = 0.1f; 
        }
    }
}
