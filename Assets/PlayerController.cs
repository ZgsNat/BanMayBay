using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*public float movespeed = 5f;
    public Rigidbody2D rb;
    public Fire fire;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2 (moveX, moveY);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
    }*/
    public float movespeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    private BoxCollider2D backgroundCollider;
    public GameObject background;
    /*private BoxCollider2D collider;*/
    // Start is called before the first frame update
    void Start()
    {
        backgroundCollider = background.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Procession Input
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = new Vector3(moveX, moveY, 0);
        Vector3 newPosition = transform.position + moveDirection * movespeed * Time.deltaTime;

        // Constrain the player's position within the background's collider bounds
        Vector3 clampedPosition = backgroundCollider.bounds.ClosestPoint(newPosition);
        transform.position = clampedPosition;
        //moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
    }
}
