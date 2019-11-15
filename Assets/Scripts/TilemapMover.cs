using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapMover : MonoBehaviour
{
    private void Start()
    {
        transform.Translate(Vector2.left * Time.deltaTime * GameManager.manager.tilespeed);
    }
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * GameManager.manager.tilespeed);
    }

   
}
