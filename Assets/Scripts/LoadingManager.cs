using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public GameObject loadingobj;


    public void loadingActive()
    {
        loadingobj.SetActive(true);
        Invoke("loadingDeactive", 1.95f);
    }

    public void loadingDeactive()
    {
        loadingobj.SetActive(false);
    }
    
}
