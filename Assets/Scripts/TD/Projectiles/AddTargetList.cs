using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTargetList : MonoBehaviour
{
    [SerializeField] private AOE_Slow slow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        slow.enemyAi.Add(collision.gameObject.GetComponent<TD_AI>());
    }
}
