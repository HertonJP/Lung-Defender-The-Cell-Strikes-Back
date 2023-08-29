using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChooseTalentPanel : MonoBehaviour
{
    public TalentManager talentManager;
    public playerStats playerStats;
    public GameObject panel;
    public Button[] talentButtons;
    [SerializeField] private AudioSource showPanelSFX;
    [SerializeField] private AudioSource chooseTalentSFX;

    public void ShowPanel()
    {
        panel.SetActive(true);
        showPanelSFX.Play();
        List<Talent> randomTalents = new List<Talent>();
        List<Talent> excludeList = new List<Talent>();

        for (int i = 0; i < 3; i++)
        {
            Talent randTalent = talentManager.RandomTalent(excludeList);
            if (randTalent == null) 
            {
                break;
            }

            randomTalents.Add(randTalent);
            excludeList.Add(randTalent);
            talentButtons[i].image.sprite = randTalent.talentImage;
            int index = i;

            talentButtons[i].onClick.RemoveAllListeners();
            talentButtons[i].onClick.AddListener(() => ChooseTalent(randomTalents[index]));
        }

        Time.timeScale = 0f;
    }

    public void ChooseTalent(Talent chosenTalent)
    {
        chooseTalentSFX.Play();
        Time.timeScale = 1f;
        panel.SetActive(false);
        talentManager.ActivateTalent(chosenTalent);
    }
}