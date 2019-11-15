using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutTilemapInFront : MonoBehaviour
{
    public GameObject player;
    public GameObject[] tileMaps;
    public bool playerTouchedputTile;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //dont have player hit have object child of camera hit
        //player can hit object multiple times. figure out way to prevent that
        
        if (collision.tag == "Player")
        {
            if(playerTouchedputTile == false)
            {
                Debug.Log("putTileNow");
                //tileMaps[Random.Range(0, tileMaps.Length)].transform.position = new Vector2(gameObject.transform.position.x + GameManager.manager.movetiledistance, gameObject.transform.position.y);
                playerTouchedputTile = true;
            }
                
        }
        
        
    }
}
