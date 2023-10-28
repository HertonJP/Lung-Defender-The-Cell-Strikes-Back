using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public bool isStunned = false;
    public float duration;
    public GameObject confuseEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStunned)
        {
            
            StartCoroutine(StunCoroutine());
        }
    }

    private IEnumerator StunCoroutine()
    {
        isStunned = false;
        confuseEffect.SetActive(true);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(duration);
        confuseEffect.SetActive(false);
        GetComponent<Rigidbody2D>().constraints = ~RigidbodyConstraints2D.FreezeAll;
    }
}
