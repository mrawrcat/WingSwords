using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBarrer : MonoBehaviour
{
    private roomGenDownwell roomGen;
    private HelperD helper;
    public float releaseBarrier;
    // Start is called before the first frame update
    void Start()
    {
        roomGen = FindObjectOfType<roomGenDownwell>();
        helper = FindObjectOfType<HelperD>();
        releaseBarrier = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(roomGen.stopGen == true)
        {
            releaseBarrier -= Time.deltaTime;
            if(releaseBarrier <= 0)
            {
                gameObject.SetActive(false);
                helper.speedRunning = true;
            }
        }
    }

   
}
