using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBarrer : MonoBehaviour
{
    private roomGenDownwell roomGen;
    // Start is called before the first frame update
    void Start()
    {
        roomGen = FindObjectOfType<roomGenDownwell>();
    }

    // Update is called once per frame
    void Update()
    {
        if(roomGen.stopGen == true)
        {
            gameObject.SetActive(false);
        }
    }
}
