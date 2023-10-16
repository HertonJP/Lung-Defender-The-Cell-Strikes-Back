using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;
    [SerializeField] private HeroHover heroHover;

    [SerializeField] private HeroTiles[] heroes;

    public int selectedHero = -1;

    private void Awake()
    {
        main = this;
    }

    public HeroTiles GetSelectedHero()
    {
        return selectedHero >= 0 ? heroes[selectedHero] : null;
    }

    public void SetSelectedHero(int _selectedHero)
    {
        selectedHero = _selectedHero;
        if (selectedHero >= 0)
        {
            heroHover.ActivatePreview(selectedHero);
        }
    }

    public void ResetSelectedHero()
    {
        selectedHero = -1;
    }
}