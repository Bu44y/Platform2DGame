using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpSpeed = 8f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, 0f);
        }
    }
}
