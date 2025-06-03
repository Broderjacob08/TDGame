using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    [SerializeField] private Image Healthbar;

    public int moneyValue;

    void Update()
    {
        Healthbar.fillAmount -= health / 100;

        if (health <= 0)
        {
            Debug.Log("Game Over");
            MoneyManager.currentMoney += moneyValue;

            Destroy(gameObject);
        }
    }
}
