using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TD_ShopUI : MonoBehaviour
{
    bool isOpen = false;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] GameObject UI;
    [SerializeField] Sprite upSprite;
    [SerializeField] Sprite downSprite;
    [SerializeField] Image buttonImage;

    public void OnClickUI()
    {
        isOpen = !isOpen;
        if (UI.GetComponent<RectTransform>().localPosition.y == minY)
        {
            UI.GetComponent<RectTransform>().localPosition = new Vector2(UI.GetComponent<RectTransform>().localPosition.x, maxY);
            buttonImage.sprite = downSprite;
        }
        else
        {
            UI.GetComponent<RectTransform>().localPosition = new Vector2(UI.GetComponent<RectTransform>().localPosition.x, minY);
            buttonImage.sprite = upSprite;
        }
    }
}
