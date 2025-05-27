using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailUI : MonoBehaviour
{
    public GameObject selectedObject;

    public GameObject detailCanvas;
    public GameObject detailsTextBox;

    [SerializeField] private List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    // Start is called before the first frame update
    void Start()
    {
        AddTextsToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mouseWorld.x, mouseWorld.y);

            Collider2D hit = Physics2D.OverlapPoint(mousePos2D);
            Debug.Log(hit);

            if (hit != null && hit.tag == "Tower")
            {
                detailCanvas.SetActive(true);
                selectedObject = hit.gameObject;

                Vector3 details = new Vector3(selectedObject.GetComponent<TowerScript>().attackDamage, selectedObject.GetComponent<TowerScript>().range, selectedObject.GetComponent<TowerScript>().startingFireRate);
                AddDetailsToText(details.x, details.y, details.z);
            }
            {
                detailCanvas.SetActive(false);
            }
        }
    }

    void AddDetailsToText(float damage, float range, float firerate)
    {
        texts[0].text = "Name: " + selectedObject.name;
        texts[1].text = "Damage: " + damage;
        texts[2].text = "Range: " + range;
        texts[3].text = "Firerate: " + firerate;
    }

    void AddTextsToList()
    {
        foreach (Transform child in detailsTextBox.transform)
        {
            texts.Add(child.GetComponent<TextMeshProUGUI>());
        }
    }
}
