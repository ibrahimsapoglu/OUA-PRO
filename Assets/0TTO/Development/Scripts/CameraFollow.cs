using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    private float smoothSpeed = 5f;
    private Vector3 offset;

    public float ChangeSmoothSpeed
    {
        get { return smoothSpeed; }
        set { smoothSpeed = value; }
    }
    public Vector3 ChangeOffset
    {
        get { return offset; }
        set { offset = value; }
    }
    private void Awake()
    {
        ChangeOffset = new Vector3(
           transform.position.x - target.transform.position.x,
           transform.position.y - target.transform.position.y,
           transform.position.z - target.transform.position.z);
    }
    private void Start()
    {
        //print("Ofset : " + new Vector3(
        //    transform.position.x - target.transform.position.x,
        //    transform.position.y - target.transform.position.y,
        //    transform.position.z - target.transform.position.z));
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;


    }
}
