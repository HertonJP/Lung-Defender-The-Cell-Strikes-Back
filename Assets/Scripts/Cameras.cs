using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera shopCam;
    [SerializeField] private Camera bossCam;

    private void Start()
    {
        mainCam.enabled = true;
        shopCam.enabled = false;
        bossCam.enabled = false;
    }
}
