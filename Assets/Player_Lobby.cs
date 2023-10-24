using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lobby : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    [SerializeField] private AudioSource rollSFX;
    [SerializeField] private AudioSource walkSFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical")!=0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else if (Input.GetAxisRaw("Horizontal") < 0)
                GetComponent<SpriteRenderer>().flipX = false;

            if(!walkSFX.isPlaying)
                playWalkSFX();
        }
        else
        {
            if (walkSFX.isPlaying)
                walkSFX.Stop();
        }

        GetComponent<Animator>().SetBool("isRunning",moveDir != Vector2.zero);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    public void playWalkSFX()
    {
        walkSFX.Play();
    }

    public void playRollSFX()
    {
        rollSFX.Play();
    }
}
