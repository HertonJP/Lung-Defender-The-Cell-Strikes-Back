using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public bool canMove = false;
    public float horizontalMovement;
    public float verticalMovement;
    public float stamina;
    [SerializeField] private float maxStamina;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float staminaRegen;
    [SerializeField] private float staminaDecreaseAmount;
    [SerializeField] private Image staminaBar;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip walkClip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = maxStamina;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        staminaBar.fillAmount = stamina / maxStamina;

        if (canMove)
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal");
            verticalMovement = Input.GetAxisRaw("Vertical");

            if (horizontalMovement != 0 || verticalMovement != 0)
            {
                if (!source.isPlaying)
                    source.Play();
            }

            if (stamina > 0)
            {
                source.clip = walkClip;
            }
            else
            {
                if (source.isPlaying)
                    source.Stop();
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            horizontalMovement = verticalMovement = 0;
        }

        
        if (horizontalMovement != 0||verticalMovement!=0)
            stamina -= staminaDecreaseAmount;

        else if (horizontalMovement == 0 && verticalMovement == 0)
        {
            if (source.isPlaying)
                source.Stop();
            stamina += staminaRegen;
        }
            
    }

    private void FixedUpdate()
    {
        if(stamina>0)
            rb.velocity = new Vector2(horizontalMovement, verticalMovement).normalized * moveSpeed;
    }
}
