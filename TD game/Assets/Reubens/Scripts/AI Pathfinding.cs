using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathfinding : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject checkpointholder;

    Rigidbody2D rb;

    List<GameObject> pathfinding = new List<GameObject>();

    int index = 0;

    public float Whentoturn;

    SpriteRenderer spirt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spirt = GetComponent<SpriteRenderer>();

        checkpointholder = GameObject.FindGameObjectWithTag("Checkpointholder");

        for (int i = 0; i < checkpointholder.transform.childCount; i++)
        {
            pathfinding.Add(checkpointholder.transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if(rb.velocity.x < 0)
        {
            spirt.flipX = true;
        } else
        {
            spirt.flipX = false;
        }
        rb.velocity = (pathfinding[index].transform.position - transform.position).normalized;

        if (Vector2.Distance(pathfinding[index].transform.position, transform.position) <= Whentoturn)
        {
            index += 1;
            if (index >= pathfinding.Count-1)
            {
                index = pathfinding.Count - 1;
            }
        }
    }
}
