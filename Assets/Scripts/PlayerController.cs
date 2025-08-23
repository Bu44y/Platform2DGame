using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpSpeed = 8f;

    private Animator anim;

    public LayerMask groundLayer;
    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        checkGrounded();
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

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, 0f);
        }

        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));
        anim.SetBool("isJumping", isGrounded);
    }

    public void checkGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction,distance,groundLayer);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("KillPlane"))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Platformer"))
        {
            transform.parent = target.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Platformer"))
        {
            transform.parent = null;
        }
    }
}
