using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableCharButton : MonoBehaviour
{
    public void DisableButton()
    {
        GetComponent<Button>().interactable = false;
    }
}
