using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float smooth;
    private Vector3 targetPosition;


    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position,targetPosition,smooth * Time.deltaTime);
    }
}
