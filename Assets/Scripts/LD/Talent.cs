using UnityEngine;

[CreateAssetMenu(fileName = "New Talent", menuName = "Talent/BaseTalent")]
public class Talent : ScriptableObject
{
    public string talentName;
    public Sprite talentImage;
    public bool isActive;

    public virtual void Activate(playerStats player)
    {
        // Default implementation or even nothing at all
    }
}