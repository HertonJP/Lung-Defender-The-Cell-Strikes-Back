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
        lastActivatedTime = Time.time - lifestealCooldown;
        TalentUIManager.Instance.lifesteal.SetActive(true);
        MonoBehaviour host = player.GetComponent<MonoBehaviour>();
        if (host != null)
        {
            host.StartCoroutine(CheckForEKey(player));
        }
    }

    private IEnumerator CheckForEKey(playerStats player)
    {
        SpriteRenderer playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        while (true)
        {
            float currentTime = Time.time;

            if (currentTime - lastActivatedTime >= lifestealCooldown)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("ngelifesteal");
                    lastActivatedTime = currentTime;
                    player.isLifestealActive = true;
                    player.lifestealEndTime = Time.time + lifestealDuration;

                    if (playerSpriteRenderer != null)
                    {
                        playerSpriteRenderer.color = new Color(0.5f, 1f, 0.5f);
                    }

                    yield return new WaitForSeconds(lifestealDuration);

                    if (playerSpriteRenderer != null)
                    {
                        playerSpriteRenderer.color = Color.white;
                    }

                    player.isLifestealActive = false;
                }
            }
            yield return null;
        }
    }
}