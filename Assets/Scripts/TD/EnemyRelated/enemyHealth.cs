using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float HP = 2;
    [SerializeField] private int worth = 20;
    [SerializeField] private List<SpriteRenderer> srList = new();
    [SerializeField] private Material flashMats;
    [SerializeField] private Material normalMats;
    [SerializeField] private float flashDuration;
    [SerializeField] private Color slowedColor;
    private bool startedFlash = false;
    private bool isDestroyed = false;
    public void TakeDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0 && !isDestroyed)
        {
            TD_Spawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(worth);
            isDestroyed = true;
            Destroy(gameObject);
        }
        if(!startedFlash)
            StartCoroutine(Flash());
    }

    private IEnumerator Flash()
    {
        startedFlash = true;
        foreach (SpriteRenderer sr in srList)
        {
            sr.material = flashMats;    
        }
        yield return new WaitForSeconds(flashDuration);
        foreach (SpriteRenderer sr in srList)
        {
            sr.material = normalMats;
        }
        startedFlash = false;
    }

    public IEnumerator SlowedEffect(float duration)
    {
        foreach(SpriteRenderer sr in srList)
        {
            sr.color = slowedColor;
        }
        yield return new WaitForSeconds(duration);
        foreach (SpriteRenderer sr in srList)
        {
            sr.color = Color.white;
        }
    }

}
