using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float horizontalMovement;
    public float verticalMovement;
    public float stamina;
    [SerializeField] private float maxStamina;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float staminaRegen;
    [SerializeField] private float staminaDecreaseAmount;
    [SerializeField] private Image staminaBar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        staminaBar.fillAmount = stamina / maxStamina;
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        if (stamina >0)
        {
            rb.velocity = new Vector2(horizontalMovement, verticalMovement).normalized * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
        if (horizontalMovement != 0||verticalMovement!=0)
            stamina -= staminaDecreaseAmount;
        else if(horizontalMovement==0&&verticalMovement==0)
            stamina += staminaRegen;
    }
}
