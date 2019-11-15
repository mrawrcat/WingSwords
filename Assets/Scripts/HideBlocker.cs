using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBlocker : MonoBehaviour
{
    public GameObject blocker;
    public bool hide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hide == true)
        {
            blocker.SetActive(false);
        }
        else
        {
            blocker.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            hide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hide = false;
        }
    }
}
