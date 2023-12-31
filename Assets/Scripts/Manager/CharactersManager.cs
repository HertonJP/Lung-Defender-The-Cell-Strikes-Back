using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersManager : MonoBehaviour
{
    public List<GameObject> spawnedCharacters = new();
    public static CharactersManager Instance;
    public int currIndex = 0;
    public Image nextCharImage;
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedCharacters.Count > 0)
        {
            spawnedCharacters[currIndex].GetComponent<VisualRangeActivation>().EnableVisual();
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && spawnedCharacters.Count>1)
        {
            DisableCharacter();
            currIndex++;
            if (currIndex == spawnedCharacters.Count)
            {
                currIndex = 0;
            }
            EnableCharacter();
        }

        if (spawnedCharacters.Count > 1)
        {
            if(currIndex+1 != spawnedCharacters.Count)
                nextCharImage.sprite = spawnedCharacters[currIndex + 1].GetComponent<Heroes>().charImage;
            else
                nextCharImage.sprite = spawnedCharacters[0].GetComponent<Heroes>().charImage;
        }
    }

    public void EnableCharacter()
    {
        spawnedCharacters[currIndex].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        spawnedCharacters[currIndex].GetComponent<Movement>().canMove = true;
        spawnedCharacters[currIndex].GetComponent<VisualRangeActivation>().EnableVisual();
    }

    private void DisableCharacter()
    {
        spawnedCharacters[currIndex].GetComponent<Movement>().canMove = false;
        spawnedCharacters[currIndex].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        spawnedCharacters[currIndex].GetComponent<Heroes>().animState.state = AnimationState.States.Idle;
        spawnedCharacters[currIndex].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        spawnedCharacters[currIndex].GetComponent<VisualRangeActivation>().DisableVisual();
    }
}
