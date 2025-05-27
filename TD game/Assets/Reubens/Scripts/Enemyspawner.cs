using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> enemies = new List<GameObject>();

    int index;

    public GameObject startposition;

    float cooldown;
   
    float timer;
    
    void Start()
    {
        cooldown = Random.Range(5, 11);
        
        timer = cooldown;

        startposition = GameObject.FindGameObjectWithTag("Start");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index],startposition.transform.position, Quaternion.identity);
            cooldown = Random.Range(5, 11);
            timer = cooldown;
        }
    }
}
