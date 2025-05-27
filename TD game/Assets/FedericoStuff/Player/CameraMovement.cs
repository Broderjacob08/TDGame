using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private KeyCode leftMoveButton = KeyCode.A;
    [SerializeField] private KeyCode rightMoveButton = KeyCode.D;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2();

        if (Input.GetKey(leftMoveButton))
        {
            rb.velocity = Vector2.left * moveSpeed;
        }
        if (Input.GetKey(rightMoveButton))
        {
            rb.velocity = Vector2.right * moveSpeed;
        }
    }
}
