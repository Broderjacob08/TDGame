using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttack : MonoBehaviour
{
    public enum EnemyType
    {
        Melee,
        Bomber,
        Ranged
    }

    [Header("EnemyType")]
    [SerializeField] private EnemyType enemyType;

    [Header("General Settings")]
    public GameObject castleTarget;
    public float attackDamage;
    public float maxAttackSpeed;
    public float minAttackSpeed;
    private float startAttackTimer;

    [SerializeField] private float maxDistanceForRangedAttacks;

    [SerializeField] private bool inRange;
    [SerializeField] private bool inArcherRange;
    bool hasAttacked;
    float attackTimer;


    // Start is called before the first frame update
    void Start()
    {
            startAttackTimer = Random.Range(minAttackSpeed, maxAttackSpeed);
            attackTimer = startAttackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        inArcherRange = CheckDistance();

        if (inRange && !hasAttacked)
        {
            if (enemyType == EnemyType.Melee)
            {
                MeleeAttack();
                hasAttacked = true;
            }
            else if (enemyType == EnemyType.Bomber)
            {
                BomberAttack();
            }
        }
        else if (enemyType == EnemyType.Ranged && !hasAttacked)
        {
            if (inArcherRange)
            {
                RangedAttack();
                hasAttacked = true;
            }
        }
        
        if (hasAttacked)
        {
            attackTimer -= Time.deltaTime;

            if(attackTimer <= 0)
            {
                attackTimer = startAttackTimer;
                hasAttacked = false;
            }
        }
    }

    void MeleeAttack()
    {
        Debug.Log("Melee Attack");

        castleTarget.GetComponent<CastleHealth>().health -= attackDamage;
    }

    void BomberAttack()
    {
        Debug.Log("Bomb Attack");
        castleTarget.GetComponent<CastleHealth>().health -= attackDamage;
        Destroy(gameObject);
    }

    void RangedAttack()
    {
        Debug.Log("Ranged Attack");
        castleTarget.GetComponent<CastleHealth>().health -= attackDamage;

        // PUT IN LINES HERE WHERE THE AI SHOULD STOP w. REUBEN //
    }

    bool CheckDistance()
    {
        Vector2 origin = transform.position;
        Vector2 direction = (castleTarget.transform.position - transform.position);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, maxDistanceForRangedAttacks);
        Debug.DrawRay(origin, direction, Color.red);

        if(hit.collider != null)
        {
            if (hit.collider.transform == castleTarget.transform)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == castleTarget)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == castleTarget)
        {
            inRange = false;
        }
    }

}
