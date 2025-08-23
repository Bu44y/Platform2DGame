using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftPoint, rightPoint;
    public float speed = 3f;
    private Rigidbody2D rb;
    public bool moveRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight && transform.position.x>rightPoint.position.x)
        {
            moveRight = false;
        }
        if (!moveRight && transform.position.x < leftPoint.position.x)
        {
            moveRight = true;
        }
        if (moveRight)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        else
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }
}
