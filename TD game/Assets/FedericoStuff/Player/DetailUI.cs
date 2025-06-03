using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailUI : MonoBehaviour
{
    public GameObject selectedObject;

    public GameObject detailCanvas;
    public GameObject detailsTextBox;
    public GameObject editingTextBox;

    [SerializeField] private List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    public GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager == null)
        {
            GameManager = gameObject;
        }
        TowerPlacement.isEditing = false;
        AddTextsToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !TowerPlacement.isEditing)
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
            }else if(hit == null || hit.tag != "Tower")
            {
                detailCanvas.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeMode();
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

    void ChangeMode()
    {
        TowerPlacement.isEditing = !TowerPlacement.isEditing;
        editingTextBox.GetComponent<TextMeshProUGUI>().text = "Editing: " + TowerPlacement.isEditing;
    }
}
