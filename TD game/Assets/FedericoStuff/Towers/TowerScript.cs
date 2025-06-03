using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    /*
     * FFrLD - Fast Firerate Low Damage
     * LFrHD - Low Firerate High Damage
     */
    public enum TowerType
    {
        FFrLD,
        LFrHD
    }

    [Header("TowerType")]
    [SerializeField] private TowerType towerType;

    [Header("General Settings")]
    public float attackDamage;
    public float startingFireRate;
    public float range;
    float FireRate;

    bool hasAttacked;

    public int moneyValue;

    [SerializeField] private List<GameObject> enemy = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        FireRate = startingFireRate;

        GetComponent<BoxCollider2D>().size = new Vector2(range, range);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAttacked)
        {
            if (enemy.Count > 0 && enemy[0] != null)
            {
                enemy[0].GetComponent<EnemyHealth>().health -= attackDamage;
                hasAttacked = true;
            }
            else
            {
                hasAttacked = false;
            }
        }

        if (hasAttacked)
        {
            FireRate -= Time.deltaTime;

            if(FireRate <= 0)
            {
                FireRate = startingFireRate;
                hasAttacked = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemy.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy.Remove(other.gameObject);
        }
    }
}
