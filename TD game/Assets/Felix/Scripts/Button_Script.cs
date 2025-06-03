using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Script : MonoBehaviour
{
    
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(1.125f, 1.7083f);
        image = GetComponent<Image>();
        image.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter()
    {
        transform.localScale = new Vector2(1.2f, 2);
        image.color = Color.gray;



    }

    public void PointerExit()
    {
        transform.localScale = new Vector2(1.125f, 1.7083f);
        image.color = Color.white;
    }

    public void OnClick()
    {
        
    }
}
