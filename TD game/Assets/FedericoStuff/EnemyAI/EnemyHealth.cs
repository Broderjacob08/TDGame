using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField] private Image Healthbar;

    private GameObject worldSpaceCanvas;
    private GameObject healthbarObject;

    public int moneyValue;

    private void Start()
    {
        worldSpaceCanvas = transform.GetChild(0).gameObject;
        healthbarObject = worldSpaceCanvas.transform.GetChild(1).gameObject;

        Healthbar = healthbarObject.GetComponent<Image>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        Healthbar.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            MoneyManager.currentMoney += moneyValue;

            Destroy(gameObject);
        }
    }
}
