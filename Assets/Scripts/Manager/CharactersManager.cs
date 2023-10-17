using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public List<GameObject> spawnedCharacters = new();
    public static CharactersManager Instance;
    public int currIndex = 0;
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
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisableCharacter();
            currIndex++;
            if (currIndex == spawnedCharacters.Count)
            {
                currIndex = 0;
            }
            EnableCharacter();
        }
    }

    public void EnableCharacter()
    {
        spawnedCharacters[currIndex].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        spawnedCharacters[currIndex].GetComponent<Movement>().enabled = true;
        spawnedCharacters[currIndex].GetComponent<VisualRangeActivation>().EnableVisual();
    }

    private void DisableCharacter()
    {
        spawnedCharacters[currIndex].GetComponent<Movement>().enabled = false;
        spawnedCharacters[currIndex].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        spawnedCharacters[currIndex].GetComponent<Heroes>().animState.state = AnimationState.States.Idle;
        spawnedCharacters[currIndex].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        spawnedCharacters[currIndex].GetComponent<VisualRangeActivation>().DisableVisual();
    }
}
