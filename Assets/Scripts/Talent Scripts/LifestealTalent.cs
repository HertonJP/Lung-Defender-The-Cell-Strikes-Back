using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "LifestealTalent", menuName = "Talents/Lifesteal")]
public class LifestealTalent : Talent
{
    public float lifestealDuration = 5f;
    public float lifestealCooldown = 20f;
    private float lastActivatedTime = 0f;

    public override void Activate(playerStats player)
    {
        MonoBehaviour host = player.GetComponent<MonoBehaviour>();
        if (host != null)
        {
            host.StartCoroutine(CheckForEKey(player));
        }
    }

    private IEnumerator CheckForEKey(playerStats player)
    {
        while (true)
        {
            float currentTime = Time.time;

            if (currentTime - lastActivatedTime >= lifestealCooldown)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    lastActivatedTime = currentTime;
                    player.isLifestealActive = true;
                    yield return new WaitForSeconds(lifestealDuration);
                    player.isLifestealActive = false;
                }
            }
            yield return null;
        }
    }
}