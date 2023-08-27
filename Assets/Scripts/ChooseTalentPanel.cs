using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChooseTalentPanel : MonoBehaviour
{
    public TalentManager talentManager;
    public playerStats playerStats;
    public GameObject panel;
    public Button[] talentButtons;

    public void ShowPanel()
    {
        panel.SetActive(true);

        List<Talent> randomTalents = new List<Talent>();

        for (int i = 0; i < 3; i++)
        {
            Talent randTalent = talentManager.RandomTalent();
            randomTalents.Add(randTalent);
            talentButtons[i].image.sprite = randTalent.talentImage;
            int index = i;

            talentButtons[i].onClick.RemoveAllListeners();
            talentButtons[i].onClick.AddListener(() => ChooseTalent(randomTalents[index]));
        }

        Time.timeScale = 0f;
    }

    public void ChooseTalent(Talent chosenTalent)
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
        talentManager.ActivateTalent(chosenTalent);
    }
}