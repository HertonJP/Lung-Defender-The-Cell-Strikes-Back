using System.Collections.Generic;
using UnityEngine;

public class TalentManager : MonoBehaviour
{
    public List<Talent> allTalents;
    public List<Talent> availableTalents;
    public playerStats player;

    private void Start()
    {
        availableTalents = new List<Talent>(allTalents);
    }

    public Talent RandomTalent()
    {
        int index = Random.Range(0, availableTalents.Count);
        Talent selected = availableTalents[index];
        return selected;
    }

    public void ActivateTalent(Talent talent)
    {
        talent.Activate(player);
        availableTalents.Remove(talent);
    }
}