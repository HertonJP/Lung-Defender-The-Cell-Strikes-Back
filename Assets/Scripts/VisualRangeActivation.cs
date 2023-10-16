using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRangeActivation : MonoBehaviour
{
    [SerializeField] private HeroRangeVisual visual;
    private void OnMouseEnter()
    {
        visual.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        visual.GetComponent<SpriteRenderer>().enabled = false;
    }
}
