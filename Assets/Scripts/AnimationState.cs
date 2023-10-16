using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    public enum States
    {
        Idle,
        Attack,
        Walk
    }

    [SerializeField] private Animator anim;
    public States state;

    [SerializeField] private string idleAnimName;
    [SerializeField] private string attackAnimName;
    [SerializeField] private string walkAnimName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == States.Idle)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(idleAnimName) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                return;
            }
            if(anim.GetCurrentAnimatorStateInfo(0).IsName(attackAnimName) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                return;
            }

            PlayIdleAnim();
        }
            

        if (state == States.Attack)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(attackAnimName) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                return;
            }else if (anim.GetCurrentAnimatorStateInfo(0).IsName(attackAnimName) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                state = States.Idle;
            }
            
            PlayAttackAnim();
        }
            

        if (state == States.Walk)
        {


            if (anim.GetCurrentAnimatorStateInfo(0).IsName(walkAnimName) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                return;
            }
            PlayWalkAnim();
        }
            
    }

    private void PlayIdleAnim()
    {
        anim.Play(idleAnimName);
    }    
    private void PlayAttackAnim()
    {
        anim.Play(attackAnimName);
    }    
    private void PlayWalkAnim()
    {
        anim.Play(walkAnimName);
    }

    public void StopPlay()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            anim.StopPlayback();
        }
    }

}
