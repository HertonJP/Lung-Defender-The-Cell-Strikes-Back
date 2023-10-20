using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_ShopUI : MonoBehaviour
{
    bool isOpen = false;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] GameObject UI;

    public void OnClickUI()
    {
        isOpen = !isOpen;
        if (UI.GetComponent<RectTransform>().localPosition.y == minY)
            UI.GetComponent<RectTransform>().localPosition = new Vector2(UI.GetComponent<RectTransform>().localPosition.x, maxY);
        else
            UI.GetComponent<RectTransform>().localPosition = new Vector2(UI.GetComponent<RectTransform>().localPosition.x, minY);

    }
}
