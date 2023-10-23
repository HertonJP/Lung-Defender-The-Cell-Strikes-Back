using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class youWinSFX : MonoBehaviour
{
    [SerializeField] private AudioSource WinSFX;


    public void playWinSFX()
    {
        WinSFX.Play();
    }
}
