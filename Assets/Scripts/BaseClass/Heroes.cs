using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Heroes : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] protected int manaIncrease;
    public GameObject _projectilesPrefab { get; private set;}

    [SerializeField] private Transform firingPoint;
    public Transform _firingPoint { get; private set; }

    [SerializeField] protected int maxMana = 100;
    public float targetingRange = 3f;

    [SerializeField] private float attackSpeed = 1f;
    public float _attackSpeed { get;  set; }

    [SerializeField] protected int mana;
    [SerializeField] protected int damage;
    public int _damage { get; set; }
    [SerializeField] protected Transform target;
    protected float timeUntilFire = 2;
    public AnimationState animState;

    [SerializeField] Movement movement;
    [SerializeField] protected List<Collider2D> hitTargets = new();

    public virtual void Start()
    {
        mana = 0;

        InitializeData();
    }

    public virtual void Update()
    {
        
        projectilesPrefab.GetComponent<Projectiles>()._projectilesDamage = _damage;

        if ((movement.horizontalMovement != 0 || movement.verticalMovement != 0) && movement.stamina > 0 && movement.enabled == true)
        {
            if (movement.horizontalMovement < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

            if (movement.horizontalMovement > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            animState.state = AnimationState.States.Walk;
            timeUntilFire = 0;
            return;
        }

        if(movement.horizontalMovement ==0 && movement.verticalMovement == 0)
        {
            animState.state = AnimationState.States.Idle;
        }

        if (target == null)
        {
            FindTarget();
            animState.state = AnimationState.States.Idle;
            return;
        }

        if (!inRange())
        {
            target = null;
        }

        timeUntilFire += Time.deltaTime;

    }

    protected virtual void Attack()
    {
        mana += manaIncrease;
    }

    protected virtual void Ulti()
    {   
    }

    private bool inRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    protected void FindTarget()
    {
        hitTargets.Clear();
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, transform.position, 0f, enemyMask);
        foreach(RaycastHit2D r in hits)
        {
            hitTargets.Add(r.collider);
        }
        if(hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    private void InitializeData()
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _firingPoint = firingPoint;
        _projectilesPrefab = projectilesPrefab;
    }
}
