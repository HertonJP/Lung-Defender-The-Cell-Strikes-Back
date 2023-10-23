using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;
    public Animator camBoss;

    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
        camBoss.SetTrigger("Shake");
    }
}
