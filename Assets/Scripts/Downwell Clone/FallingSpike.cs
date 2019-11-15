using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    public float startfall;
    // Start is called before the first frame update
    void Start()
    {
        startfall = 10;
    }

    // Update is called once per frame
    void Update()
    {
        startfall -= Time.deltaTime;

        if(startfall <= 0)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 1f);
        }
    }
}
