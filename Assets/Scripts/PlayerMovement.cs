using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public playerStats player;
    public Rigidbody2D rb;
    public Camera cam;
    public Collider2D rolloutHitbox;
    private bool facingRight = false;
    private Animator animator;
    private bool isRolling = false;
    [SerializeField] private AudioSource rollSFX;
    [SerializeField] private AudioSource walkSFX;

    private float lastRollTime = 0f;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rolloutHitbox.enabled = false;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        float currentTime = Time.time;

        if (currentTime - lastRollTime >= player.rollCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
            {
                StartRoll();
                lastRollTime = currentTime;
            }
        }

        if ((movement.x < 0 && facingRight) || (movement.x > 0 && !facingRight))
        {
            Flip();
        }

        bool isMoving = movement.magnitude > 0.1f;
        animator.SetBool("isRunning", isMoving);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void playWalkSFX()
    {
        walkSFX.Play();
    }
    public void playRollSFX()
    {
        rollSFX.Play();
    }
    public void DashRoll()
    {
        player.movementSpeed += 15;
    }
    public void EndDashRoll()
    {
        player.movementSpeed -= 15;
    }
    private void StartRoll()
    {
        animator.SetTrigger("isRolling");
        isRolling = true;

        if (player.isRollout)
        {
            rolloutHitbox.enabled = true;
        }
    }

    private void EndRoll()
    {
        animator.ResetTrigger("isRolling");
        isRolling = false;
        rolloutHitbox.enabled = false;
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