using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class ComboAttack : MonoBehaviour
{
    public int comboCount;
    private Animator animator;
    private bool isAttacking;
    private float comboTimeout = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking && Time.timeScale != 0 )
        {
            Debug.Log("dalem input");
            isAttacking = true;
            animator.SetTrigger("" + comboCount);
        }
    }


    public void StartCombo()
    {
        isAttacking = false;
        if(comboCount < 3 && Time.timeScale != 0)
        {
            comboCount++;
        }
    }
    

    public void StopCombo()
    {
        isAttacking = false;
        comboCount = 0;
    }
}