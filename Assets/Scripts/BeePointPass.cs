using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePointPass : MonoBehaviour
{
    public GameObject beepointpass;
    // Start is called before the first frame update
    void Start()
    {
        beepointpass = GameObject.FindWithTag("BeePassPoint");
        if (transform.position.x < beepointpass.transform.position.x)
        {
            GetComponentInChildren<Bee>().isPassedPoint = true;
        }
        if (transform.position.x > beepointpass.transform.position.x)
        {
            GetComponentInChildren<Bee>().isPassedPoint = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < beepointpass.transform.position.x)
        {
            GetComponentInChildren<Bee>().isPassedPoint = true;
        }
        if (transform.position.x > beepointpass.transform.position.x)
        {
            GetComponentInChildren<Bee>().isPassedPoint = false;
        }

    }
}
