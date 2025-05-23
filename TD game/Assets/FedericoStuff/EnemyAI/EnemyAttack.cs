using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("EnemyType")]
    [SerializeField]
    private bool isMelee;
    [SerializeField]
    private bool isBomber;

    [Header("General Settings")]
    public GameObject castleTarget;
    public float attackDamage;
    public float maxAttackSpeed;
    public float minAttackSpeed;
    private float startAttackTimer;

    public bool inRange;
    bool hasAttacked;
    float attackTimer;


    // Start is called before the first frame update
    void Start()
    {
        if (isMelee)
        {
            startAttackTimer = Random.Range(minAttackSpeed, maxAttackSpeed);
            attackTimer = startAttackTimer;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && !hasAttacked)
        {
            if (isMelee)
            {
                MeleeAttack();
                hasAttacked = true;
            }
            else if (isBomber)
            {
                BomberAttack();
            }
        }
        else if (hasAttacked)
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
