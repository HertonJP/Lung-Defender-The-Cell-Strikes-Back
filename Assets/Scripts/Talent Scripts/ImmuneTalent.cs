using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "ImmuneTalent", menuName = "Talents/Immune")]
public class ImmuneTalent : Talent
{
    public float immuneTime = 3f;

    public override void Activate(playerStats player)
    {
        MonoBehaviour host = player.GetComponent<MonoBehaviour>();
        if (host != null)
        {
            host.StartCoroutine(CheckForRightClick(player));
        }
    }

    private IEnumerator CheckForRightClick(playerStats player)
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(1)) 
            {
                yield return ActivateImmune(player);
            }
            yield return null; 
        }
    }

    private IEnumerator ActivateImmune(playerStats player)
    {
        SpriteRenderer playerSpriteRenderer = player.GetComponent<SpriteRenderer>();

        if (playerSpriteRenderer != null)
        {
            playerSpriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }

        Physics2D.IgnoreLayerCollision(player.gameObject.layer, LayerMask.NameToLayer("Enemy"), true);

        yield return new WaitForSeconds(immuneTime);

        if (playerSpriteRenderer != null)
        {
            playerSpriteRenderer.color = Color.white;
        }

        Physics2D.IgnoreLayerCollision(player.gameObject.layer, LayerMask.NameToLayer("Enemy"), false);
    }
}