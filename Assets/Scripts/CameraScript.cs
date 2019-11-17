using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform target;        //target for the camera to follow
    public float OffsetX, OffsetY;           //how much space should be between the object and target


    void Update()
    {
        //follow the target
        transform.position = new Vector3(transform.position.x + OffsetX, target.position.y + OffsetY, transform.position.z);
    }
}
