using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRangeActivation : MonoBehaviour
{
    [SerializeField] private HeroRangeVisual visual;
    private void OnMouseEnter()
    {
        EnableVisual();
    }

    private void OnMouseExit()
    {
        DisableVisual();
    }

    public void EnableVisual()
    {
        visual.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void DisableVisual()
    {
        visual.GetComponent<SpriteRenderer>().enabled = false;
    }
}
