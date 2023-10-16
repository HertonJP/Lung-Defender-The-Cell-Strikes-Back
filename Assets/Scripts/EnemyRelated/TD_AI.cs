using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_AI : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    [field:SerializeField]
    public float _speed { get; private set; }
    [SerializeField] private Rigidbody2D rb;

    private Transform target;
    private int pathIndex = 0;
    
    public bool isSlowed = false;
    public float slowedSpeed;
    public float slowDuration;

    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.main.path[pathIndex];
        _speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if(pathIndex == LevelManager.main.path.Length)
            {
                TD_Spawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }

        if (isSlowed)
        {
            StartCoroutine(Slowed(slowDuration, slowedSpeed));
        }

    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * _speed;
    }

    public IEnumerator Slowed(float duration, float slowedSpeed)
    {
        isSlowed = false;
        _speed =  slowedSpeed;
        yield return new WaitForSeconds(duration);
        _speed = speed;
    }
}
