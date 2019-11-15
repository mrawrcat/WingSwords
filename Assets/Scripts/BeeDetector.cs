using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeeDetector : MonoBehaviour
{
    public GameObject alarm;
    // Start is called before the first frame update
    void Start()
    {
        alarm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Bee")
        {
            Debug.Log("bee collision detected");
            if(collision.transform.position.x > transform.position.x)
            {

                alarm.SetActive(true);
            }
            if(collision.transform.position.x < transform.position.x)
            {
                alarm.SetActive(false);
            }
        }
    }
}
