using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    private bool facingRight = false;
    private Animator animator;
    private bool isRolling = false;
    private Vector3 rollDirection;

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

        rollDirection = transform.forward;

        isRolling = true;
        Vector3 targetPosition = transform.position + rollDirection * 2f;
        StartCoroutine(RollCoroutine(targetPosition));
    }

    private IEnumerator RollCoroutine(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float rollDuration = 0.5f;

        while (elapsedTime < rollDuration)
        {

            transform.position = Vector3.Lerp(transform.position, targetPosition, elapsedTime / rollDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isRolling = false;
    }

    public void FinishRoll()
    {
        isRolling = false;
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
}