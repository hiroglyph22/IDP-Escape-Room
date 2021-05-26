using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private float movementx;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        moveVelocity = moveInput.normalized * speed;
        movementx = rb.position.x;
    }

    private void FixedUpdate()
    {   
        if (EventSystem.current.currentSelectedGameObject == null)
        {
           rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }

    public void PlayerTransitionRoom2()
    {
        transform.position = new Vector3(25.41f, -1.95f, 0);
    }

    public void PlayerTransitionRoom3()
    {
        transform.position = new Vector3(3.82f, -13.82f, 0);
    }
}
