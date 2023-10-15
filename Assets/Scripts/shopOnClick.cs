using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shopOnClick : MonoBehaviour
{
    public ChooseTalentPanel talentPanel;
    private bool isOnCooldown = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0 && !isOnCooldown)
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

            if (hit && hit.collider.gameObject == this.gameObject)
            {
                talentPanel.ShowPanel();
                StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(10f);
        isOnCooldown = false;
    }
}