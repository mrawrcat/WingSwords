using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerD : MonoBehaviour
{
    public static GameManagerD managerD;

    public float health, speed, jumpforce;
    // Start is called before the first frame update
    void Start()
    {
        if (managerD == null)
        {
            managerD = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (managerD != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
