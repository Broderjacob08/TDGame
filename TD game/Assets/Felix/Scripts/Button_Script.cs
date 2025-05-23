using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(1.125f, 1.7083f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter()
    {
        transform.localScale = new Vector2(1.265625f, 1.9218375f);
    }

    public void PointerExit()
    {
        transform.localScale = new Vector2(1.125f, 1.7083f);
    }

    public void OnClick()
    {
        transform.localScale = new Vector2(300, 60);
    }
}
