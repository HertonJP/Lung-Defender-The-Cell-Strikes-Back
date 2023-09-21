using UnityEngine;

public class shopOnClick : MonoBehaviour
{
    public ChooseTalentPanel talentPanel;

    void Update()
    {
            if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

                if (hit && hit.collider.gameObject == this.gameObject)
                {
                    talentPanel.ShowPanel();
                }
            }
        }
}