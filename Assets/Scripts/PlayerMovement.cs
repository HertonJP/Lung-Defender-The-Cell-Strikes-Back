using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public playerStats player;
    public Rigidbody2D rb;
    public Camera cam;
    private bool facingRight = false;
    private Animator animator;
    private bool isRolling = false;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        

        if (Input.GetKeyDown(KeyCode.Q) && !isRolling)
        {
            StartRoll();
        }
        if ((movement.x < 0 && facingRight) || (movement.x > 0 && !facingRight))
        {
            Flip();
        }
        bool isMoving = movement.magnitude > 0.1f;
        animator.SetBool("isRunning", isMoving);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void StartRoll()
    {
        animator.SetTrigger("isRolling");
    }


    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * player.movementSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Border"))
        {
            Debug.Log("kena border");
            rb.velocity = Vector2.zero;
        }
    }

    void Flip()
    {

        facingRight = !facingRight;


        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}