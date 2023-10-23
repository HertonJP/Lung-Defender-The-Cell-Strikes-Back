using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public ParticleSystem dust;
    [SerializeField] public float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    private bool facingRight = true;

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if ((movement.x < 0 && facingRight) || (movement.x > 0 && !facingRight))
        {
            
            Flip();
            CreateDust();
        }
        if (transform.position.y >= 39)
        {
            transform.position = new Vector3(transform.position.x, 39, 0);
        }

        if (transform.position.y <= -39)
        {
            transform.position = new Vector3(transform.position.x, -39, 0);
        }
        if (transform.position.x >= 52)
        {
            transform.position = new Vector3(52, transform.position.y, 0);
        }
        if (transform.position.x <= -52)
        {
            transform.position = new Vector3(-52, transform.position.y, 0);
        }


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Border"))
        {
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

    void CreateDust()
    {
        dust.Play();
    }
}
