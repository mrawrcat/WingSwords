using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSideRooms : MonoBehaviour
{
    public LayerMask whatIsRoom;
    private LvlGen lvlgen;

    private void Start()
    {
        lvlgen = FindObjectOfType<LvlGen>();
    }
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if(roomDetection == null && lvlgen.stopGen == true)
        {
            int rand = Random.Range(0, lvlgen.rooms.Length);
            GameObject instance = Instantiate(lvlgen.rooms[rand], transform.position, Quaternion.identity);
            instance.transform.parent = lvlgen.Grid.transform;
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
