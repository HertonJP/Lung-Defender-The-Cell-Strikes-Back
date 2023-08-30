using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public Camera mainCam;
    public Camera shopCam;
    public Camera bossCam;

    private void Start()
    {
        mainCam.enabled = false;
        shopCam.enabled = true;
        bossCam.enabled = false;
    }
}
