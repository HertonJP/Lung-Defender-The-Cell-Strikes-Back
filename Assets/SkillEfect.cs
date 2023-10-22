using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEfect : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartFX()
    {
        gameObject.SetActive(true);
        StartCoroutine(DisableDelay());
    }

    private IEnumerator DisableDelay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
