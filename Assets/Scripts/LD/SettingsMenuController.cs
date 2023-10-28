using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenuController : MonoBehaviour, IMenu
{
    private Canvas canvas;

    public void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Hide()
    {
        canvas.enabled = false;
    }

    public void Show()
    {
        canvas.enabled = true;
    }
}
