using UnityEngine;

public class LabClick : MonoBehaviour
{
    public GameObject labPanel;
    private float cooldownTime = 1.0f;
    private float nextActionTime = 0.0f;

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
            {
                Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
                if (hit && hit.collider.gameObject == this.gameObject)
                {
                    nextActionTime = Time.time + cooldownTime;
                    Time.timeScale = 0;
                    labPanel.SetActive(true);
                }
            }
        }
    }
}