using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Heroes : MonoBehaviour
{
    public Sprite charImage;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject projectilesPrefab;
    [SerializeField] protected int manaIncrease;
    public GameObject _projectilesPrefab { get; private set;}

    [SerializeField] private Transform firingPoint;
    public Transform _firingPoint { get; private set; }

    [SerializeField] protected int maxMana = 100;
    public float targetingRange = 3f;

    [SerializeField] private float attackSpeed = 1f;
    [field:SerializeField]
    public float _attackSpeed { get;  set; }

    [SerializeField] protected int mana;
    [SerializeField] protected int damage;
    public int _damage { get; set; }
    [SerializeField] protected Transform target;
    protected Vector3 lastTargetPos;
    protected float timeUntilFire = 2;
    public AnimationState animState;

    [SerializeField] Movement movement;
    [SerializeField] protected List<Collider2D> hitTargets = new();
    [SerializeField] private Image manaBar;
    
    protected bool isIdle => !(movement.horizontalMovement != 0 || movement.verticalMovement != 0);

    public virtual void Start()
    {
        mana = 0;
        UpdateManaBar();
        InitializeData();
       
    }

    public virtual void Update()
    {

        projectilesPrefab.GetComponent<Projectiles>()._projectilesDamage = _damage;
        timeUntilFire += Time.deltaTime;
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
            
            return;
        }

        if(target!=null)
            lastTargetPos = target.position;

        if(movement.horizontalMovement ==0 && movement.verticalMovement == 0)
            animState.state = AnimationState.States.Idle;

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
    }

    protected virtual void Attack()
    {
        mana += manaIncrease;
        UpdateManaBar();
    }

    protected virtual void Ulti()
    {
        LevelManager.main.skillFX.StartFX();
    }

    private bool inRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    protected void FindTarget()
    {
        RaycastHit2D[] hits  = Physics2D.CircleCastAll(transform.position, targetingRange, transform.position, 0f, enemyMask);
        if(hits.Length>0)
            target = hits[0].transform;
    }
    
    //private void OnDrawGizmosSelected()
    //{
    //    // Handles.color = Color.cyan;
    //    // Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    //}

    private void InitializeData()
    {
        _damage = damage;
        _attackSpeed = attackSpeed;
        _firingPoint = firingPoint;
        _projectilesPrefab = projectilesPrefab;
    }

    public void UpdateManaBar()
    {
        manaBar.fillAmount =(float) mana / maxMana;
    }
}
