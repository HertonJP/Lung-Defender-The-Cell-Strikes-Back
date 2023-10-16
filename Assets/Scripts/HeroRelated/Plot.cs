using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Plot : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] HeroHover hover;
    [SerializeField] Tilemap tileMap;

    [SerializeField] private GameObject hero;

    [SerializeField] private List<Button> characterShopButton;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlaceCharacter();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BuildManager.main.ResetSelectedHero();
            HeroHover.Instance.ResetPreviewHero();
            hero = null;
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
                CharactersManager.Instance.spawnedCharacters[0].GetComponent<Movement>().enabled = true;
                CharactersManager.Instance.spawnedCharacters[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
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
        return Time.timeScale != 0 && tileMap.GetTile(tileMap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition))) != null && hit.collider == null;
    }
}
