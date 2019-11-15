using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    ObjectPooler objectPooler;
    //public float timer, timeToSpawn;
    public GameObject Grid;

    public string[] tags;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.instance;
        //timer = timeToSpawn;
        
        
    }

    private void FixedUpdate()
    {
        //timer -= Time.deltaTime;
        //if(GameManager.manager.dead == false)
        //{
            
        //        ObjectPooler.instance.spawnFromPool(tags[Random.Range(0,tags.Length)], transform.position);
        //        timer = timeToSpawn;
            
        //}
        
        
    }

    public void spawnTile(Vector2 pos)
    {
      ObjectPooler.instance.spawnFromPool(tags[Random.Range(0, tags.Length)], pos);
    }
}
