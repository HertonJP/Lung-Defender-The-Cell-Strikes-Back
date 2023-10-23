using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour
{
    [SerializeField] HeroHover hover;
    [SerializeField] Tilemap tileMap;

    [SerializeField] private GameObject hero;

    [SerializeField] private List<Button> characterShopButton;

    private void Start()
    {
        foreach(string s in GameManager.Instance.buttonPlayerPrefs)
        {
            if(PlayerPrefs.HasKey(s) && PlayerPrefs.GetInt(s) == 1)
            {
                FindButtonByName(s);
            }
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlaceCharacter();
        }
    }

    private void PlaceCharacter()
    {
        if (ValidateCharacterPlacement())
        {
            if (hero != null)
            {
                return;
            }

            HeroTiles heroToSpawn = BuildManager.main.GetSelectedHero();

            if (heroToSpawn == null || heroToSpawn.cost > LevelManager.main.nutrition)
            {
                return;
            }

            LevelManager.main.SpendCurrency(heroToSpawn.cost);
            Vector2 spawnPosition = hover.transform.position;
            hero = Instantiate(heroToSpawn.prefab, spawnPosition, Quaternion.identity);

            CharactersManager.Instance.spawnedCharacters.Add(hero);
            if(CharactersManager.Instance.spawnedCharacters.Count == 1)
            {
                CharactersManager.Instance.EnableCharacter();
                CharactersManager.Instance.nextCharImage.sprite = CharactersManager.Instance.spawnedCharacters[0].GetComponent<Heroes>().charImage;
            }

            characterShopButton[BuildManager.main.selectedHero].interactable = false;
            BuildManager.main.ResetSelectedHero();
            HeroHover.Instance.ResetPreviewHero();
            // reset hero
            hero = null;
        }
    }

    private bool ValidateCharacterPlacement()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        return Time.timeScale != 0 && hit.collider == null && !EventSystem.current.IsPointerOverGameObject();
    }

    private void FindButtonByName(string name)
    {
        Button found = characterShopButton.Find(x => x.name.Contains(name));
        if (found != null)
            found.interactable = true;
        else
        {
            Debug.LogError("Button Not Found");
            return;
        }
    }
}
