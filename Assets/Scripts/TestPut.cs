using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPut : MonoBehaviour
{
    private Spawner spawner;
    public float offsetY;
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PutTile")
        {
            Debug.Log("collision detected");
            //spawner.spawnTile();

        }

        if(collision.tag == "Player")
        {
            Debug.Log("collided with player");
            Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - offsetY);
            spawner.spawnTile(pos);
            this.gameObject.SetActive(false);
        }
    }
}
