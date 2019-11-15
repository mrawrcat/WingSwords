using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGen : MonoBehaviour
{
    public GameObject Grid, player;
    public Transform[] startingPositions;
    public GameObject[] startRooms;
    public GameObject[] endRooms;
    public GameObject[] rooms;
    public float minX, maxX, minY;
    public float moveAmt;
    
    public float starttimeBtwnRoom = .25f;
    public LayerMask roomLayer;
    public bool stopGen;

    private int downCounter;
    private int direction;
    private float timeBtwnRoom;
    void Start()
    {

        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        GameObject room = Instantiate(startRooms[0], transform.position, Quaternion.identity);
        room.transform.parent = Grid.transform;

        player.transform.position = transform.position;
        direction = Random.Range(1, 6);
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
        if(direction == 1 || direction == 2)//move right
        {
            if(transform.position.x < maxX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmt, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                GameObject room = Instantiate(rooms[rand], transform.position, Quaternion.identity);
                room.transform.parent = Grid.transform;

                direction = Random.Range(1, 6);
                if(direction == 3)
                {
                    direction = 2;
                }
                else if(direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 3 || direction == 4)//move left
        {
            
            if(transform.position.x > minX)
            {
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmt, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                GameObject room = Instantiate(rooms[rand], transform.position, Quaternion.identity);
                room.transform.parent = Grid.transform;

                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 5)//move down
        {
            downCounter++;
            if(transform.position.y > minY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomLayer);
                if(roomDetection.GetComponent<RoomType>().roomType != 1 && roomDetection.GetComponent<RoomType>().roomType != 3)
                {
                    if(downCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        GameObject previousRoom = Instantiate(rooms[3], transform.position, Quaternion.identity);
                        previousRoom.transform.parent = Grid.transform;
                    }
                    else
                    {
                        Debug.Log("detected non-compatible room");
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        int randBottom = Random.Range(1, 4);
                        if (randBottom == 2)
                        {
                            randBottom = 1;
                        }
                        GameObject prevRoom = Instantiate(rooms[randBottom], transform.position, Quaternion.identity);
                        prevRoom.transform.parent = Grid.transform;

                    }
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmt);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                GameObject room = Instantiate(rooms[rand], transform.position, Quaternion.identity);
                room.transform.parent = Grid.transform;

                direction = Random.Range(1, 6);
            }
            else
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomLayer);
                roomDetection.GetComponent<RoomType>().RoomDestruction();
                int rnd = Random.Range(0,endRooms.Length);
                GameObject instance = Instantiate(endRooms[0], transform.position, Quaternion.identity);
                instance.transform.parent = Grid.transform;
                stopGen = true;
                player.SetActive(true);
            }
        }
        //GameObject room = Instantiate(rooms[0], transform.position, Quaternion.identity);
        //room.transform.parent = Grid.transform;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
