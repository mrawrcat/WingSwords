using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform target;        //target for the camera to follow
    public float Offset;           //how much space should be between the object and target


    void Update()
    {
        //follow the target on the x-axis only
        transform.position = new Vector3(transform.position.x, target.position.y + Offset, transform.position.z);
    }
}
