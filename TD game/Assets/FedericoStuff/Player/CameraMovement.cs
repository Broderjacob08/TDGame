using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    [SerializeField] private KeyCode leftMoveButton = KeyCode.A;
    [SerializeField] private KeyCode rightMoveButton = KeyCode.D;

    [SerializeField] private float negativeXLimit;
    [SerializeField] private float positiveXLimit;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2();

        if (Input.GetKey(leftMoveButton) && transform.position.x > negativeXLimit)
        {
            rb.velocity = Vector2.left * moveSpeed;
        }
        if (Input.GetKey(rightMoveButton) && transform.position.x < positiveXLimit)
        {
            rb.velocity = Vector2.right * moveSpeed;
        }
    }
}
