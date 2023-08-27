using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentUIManager : MonoBehaviour
{
    public static TalentUIManager Instance;
    [SerializeField] public GameObject berserk;
    [SerializeField] public GameObject revive;
    [SerializeField] public GameObject swift;
    [SerializeField] public GameObject doubleRoll;
    [SerializeField] public GameObject haste;
    [SerializeField] public GameObject rollout;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        berserk.SetActive(false);
        revive.SetActive(false);
        swift.SetActive(false);
        doubleRoll.SetActive(false);
        haste.SetActive(false);
        rollout.SetActive(false);
    }
}
