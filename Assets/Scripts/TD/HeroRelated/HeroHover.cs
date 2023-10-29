using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHover : MonoBehaviour
{
    private static HeroHover instance;

    private SpriteRenderer spriteRenderer;

    public Transform heroPreview;

    public static HeroHover Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<HeroHover>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        spriteRenderer = GetComponent<SpriteRenderer>();
        heroPreview = transform.GetChild(0);
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        followMouse();
    }

    private void followMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Activate(Sprite sprite)
    {
        this.spriteRenderer.sprite = sprite;
    }

    public void ActivatePreview(int index)
    {
        ResetPreviewHero();
        heroPreview.GetChild(index).gameObject.SetActive(true);
    }

    public void ResetPreviewHero()
    {
        for(int i=0; i<heroPreview.childCount; i++)
        {
            heroPreview.GetChild(i).gameObject.SetActive(false);
        }
    }
}