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

    public Talent RandomTalent(List<Talent> excludeList)
    {
        List<Talent> selectableTalents = new List<Talent>(availableTalents);
        foreach (Talent talent in excludeList)
        {
            selectableTalents.Remove(talent);
        }

        if (selectableTalents.Count == 0)
        {
            return null;
        }

        int index = Random.Range(0, selectableTalents.Count);
        Talent selected = selectableTalents[index];
        return selected;
    }

    public void ActivateTalent(Talent talent)
    {
        talent.Activate(player);
        availableTalents.Remove(talent);
    }
}