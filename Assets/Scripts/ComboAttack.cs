using UnityEngine;
using System.Collections;
using System;

public class ComboAttack : MonoBehaviour
{
    public int comboCount;
    private Animator animator;
    private bool isAttacking;
    private float lastAttackTime = 0f;
    private float comboTimeout = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    // Check for left-click input
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        if (!isAttacking)
    //        {
    //            // Start the combo
    //            StartCoroutine(ComboTimer());
    //            lastAttackTime = Time.time;
    //            isAttacking = true;
    //            PlayAttackAnimation(1);
    //        }
    //        else
    //        {
    //            // Check if the player can continue the combo
    //            float timeSinceLastAttack = Time.time - lastAttackTime;
    //            if (timeSinceLastAttack <= comboTimeout)
    //            {
    //                lastAttackTime = Time.time;
    //                int nextAttackAnim = (GetCurrentAttackAnimation() % 3) + 1;
    //                PlayAttackAnimation(nextAttackAnim);
    //            }
    //            else
    //            {
    //                // Combo timeout, restart the combo
    //                lastAttackTime = Time.time;
    //                PlayAttackAnimation(1);
    //            }
    //        }
    //    }
    //}

    private void PlayAttackAnimation(int comboStep)
    {
        animator.SetInteger("ComboStep", comboStep);
        animator.SetTrigger("Attack");
    }

    private int GetCurrentAttackAnimation()
    {
        return animator.GetInteger("ComboStep");
    }

    private IEnumerator ComboTimer()
    {
        yield return new WaitForSeconds(comboTimeout);
        isAttacking = false;
    }

    public void StartCombo()
    {
        isAttacking = false;
        if(comboCount < 3)
        {
            comboCount++;
        }
    }
    public void PlayCombo()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            animator.SetTrigger("" + comboCount);
        }
    }
    public void Update()
    {
        PlayCombo();
    }

    public void StopCombo()
    {
        isAttacking = false;
        comboCount = 0;
    }
}