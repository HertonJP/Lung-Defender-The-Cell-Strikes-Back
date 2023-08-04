using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Rigidbody2D rb;
    private Transform target;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogError("Player not found! Make sure the player has a 'Player' tag.");
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;

            rb.velocity = direction * speed;

            if (direction.x > 0 && !IsFacingRight())
            {
                Flip();
            }
            else if (direction.x < 0 && IsFacingRight())
            {
                Flip();
            }
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void Flip()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}