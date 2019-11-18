using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomGenDownwell : MonoBehaviour
{
    public GameObject Grid, player;
    public Transform[] startingPositions;
    public GameObject[] startRooms;
    public GameObject[] endRooms;
    public GameObject[] rooms;
    public float maxY;
    public float moveAmt;
    
    public float starttimeBtwnRoom = .25f;
    public LayerMask roomLayer;
    public bool stopGen;

    private int downCounter;
    private float timeBtwnRoom;
    private HelperD helper;
    private FadeUI fade;
    
    void Start()
    {
        helper = FindObjectOfType<HelperD>();
        fade = FindObjectOfType<FadeUI>();
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        GameObject room = Instantiate(startRooms[0], transform.position, Quaternion.identity);
        room.transform.parent = Grid.transform;

        player.transform.position = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwnRoom <= 0 && stopGen == false)
        {
            MoveRoom();
            timeBtwnRoom = starttimeBtwnRoom;
        }
        else
        {
            timeBtwnRoom -= Time.deltaTime;
        }
    }

    void MoveRoom()
    {
        
            downCounter++;
            if(transform.position.y > maxY)
            {
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmt);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                GameObject room = Instantiate(rooms[rand], transform.position, Quaternion.identity);
                room.transform.parent = Grid.transform;
            }
            else
            {
                //Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomLayer);
                //roomDetection.GetComponent<RoomType>().RoomDestruction();
                int rnd = Random.Range(0,endRooms.Length);
                GameObject instance = Instantiate(endRooms[0], transform.position, Quaternion.identity);
                instance.transform.parent = Grid.transform;
                stopGen = true;
                //helper.speedRunning = true;
                //player.SetActive(true);
                fade.m_Fading = false;
                
                
            }
        
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
