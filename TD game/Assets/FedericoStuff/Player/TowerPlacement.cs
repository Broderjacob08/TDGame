using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public List<GameObject> towers = new List<GameObject>();
    int i = 0;

    public float cellSize = 1f; // Size of each grid cell
    public GameObject towerEmpty;

    // Store grid positions where objects have been placed
    private HashSet<Vector2> occupiedPositions = new HashSet<Vector2>();

    public static bool isEditing;

    // MoneyManager

    void Update()
    {
        if (isEditing)
        {
            if (Input.GetMouseButtonDown(0)) // Left click
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0f;

                Vector2 snappedPosition = new Vector2(
                    Mathf.Floor(mouseWorldPos.x / cellSize) * cellSize + cellSize / 2f,
                    Mathf.Floor(mouseWorldPos.y / cellSize) * cellSize + cellSize / 2f);

                // Prevent placing if already occupied
                if (occupiedPositions.Contains(snappedPosition))
                {
                    Debug.Log("Tile already occupied!");
                    return;
                }

                SpawnTower(snappedPosition);
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                i++;
                if (i >= towers.Count)
                {
                    i = 0;
                }
            }
        }
    }

    void SpawnTower(Vector2 snappedPosition)
    {
        bool hasEnough = CheckCurrency();

        if (hasEnough)
        {
            GameObject tower = Instantiate(towers[i], snappedPosition, Quaternion.identity);
            tower.transform.parent = towerEmpty.transform;

            MoneyManager.currentMoney -= tower.GetComponent<TowerScript>().moneyValue;

            occupiedPositions.Add(snappedPosition);
        }  
    }

    bool CheckCurrency()
    {
        if (MoneyManager.currentMoney < towers[i].GetComponent<TowerScript>().moneyValue)
        {
            Debug.Log("Not Enough Money");
            return false;
        }
        else
        {
            return true;
        }
    }
}
