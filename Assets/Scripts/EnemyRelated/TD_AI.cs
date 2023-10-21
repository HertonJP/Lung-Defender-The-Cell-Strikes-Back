using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TD_AI : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    [field:SerializeField]
    public float _speed { get; private set; }
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Transform target;
    private int pathIndex = 0;
    
    public bool isSlowed = false;
    public float slowedSpeed;
    public float slowDuration;
    public bool canCheckFlip = false;

    // Start is called before the first frame update
    void Start()
    {
        switch (TD_Spawner.main.spawnPoint)
        {
            case 1:
                target = LevelManager.main.path2[pathIndex];
                break;
            default:
                target = LevelManager.main.path[pathIndex];
                break;
        }
        
        _speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            

            if(pathIndex == LevelManager.main.path.Length && TD_Spawner.main.spawnPoint==0 || pathIndex == LevelManager.main.path2.Length && TD_Spawner.main.spawnPoint !=0)
            {
                TD_Spawner.onEnemyDestroy.Invoke();
                LevelManager.main.EnemyDamage();
                LevelManager.main.UpdateHealthBar();
                Destroy(gameObject);
                return;
            }
            else
            {
                switch (TD_Spawner.main.spawnPoint)
                {
                    case 1:
                        target = LevelManager.main.path2[pathIndex];
                        CheckFlip();
                        break;
                    default:
                        target = LevelManager.main.path[pathIndex];
                        CheckFlip();
                        break;
                }
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

    private void CheckFlip()
    {
        if (target.position.x < transform.position.x)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else if (target.position.x >= transform.position.x)
        {
            transform.localEulerAngles = Vector3.zero;
        }

    }
}
