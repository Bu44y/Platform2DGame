using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platformer;
    public Transform startPoint, endPoint;
    public float speed = 3f;
    private Vector3 currentTarget;

    void Start()
    {
        currentTarget = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        platformer.transform.position = Vector3.MoveTowards(platformer.transform.position, currentTarget, speed * Time.deltaTime);

        if (platformer.transform.position == startPoint.position)
        {
            currentTarget = endPoint.position;
        }
        if (platformer.transform.position == endPoint.position)
        {
            currentTarget = startPoint.position;
        }
    }
}
