using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("EnemyType")]
    public bool isMelee;
    public bool isBomber;

    [Header("General Settings")]
    public GameObject castleTarget;
    public float attackDamage;
    public float attackSpeed;

    public bool inRange;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (isMelee)
            {
                MeleeAttack();
            }
            else if (isBomber)
            {
                BomberAttack();
            }
        }
    }

    void MeleeAttack()
    {
        Debug.Log("Melee Attack");
    }

    void BomberAttack()
    {

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
