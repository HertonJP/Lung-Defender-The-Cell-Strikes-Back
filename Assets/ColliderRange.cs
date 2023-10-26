using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRange : MonoBehaviour
{
    public List<GameObject> laserTarget = new();
    public Transform visual;
    // Start is called before the first frame update

    private void Update()
    {
        if(laserTarget.Count>0 && laserTarget[0] == null)
        {
            laserTarget.Remove(laserTarget[0]);
        }
    }

    public void EnableCollider()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().radius = visual.localScale.x * .04f;
    }

    public void DisableCollider()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        laserTarget.Clear();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("Enemy"))
        {
            laserTarget.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            laserTarget.Remove(collision.gameObject);
        }
    }
}
