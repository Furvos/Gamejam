using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public int clickForce = 200;
    public Position objPos;
    public float turnSpeed = 5f;

    Vector2 movement;
    Vector2 mousePos;
    public Position playerPos;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        // rota��o aproximar gradualmente
        // angle approach

        // rb.rotation = angleApproach(rb.rotation);
        rb.rotation = angle;
        var mouseDir = mousePos - rb.position;

        if (Input.GetMouseButton(0))
        {
            rb.AddForce(mouseDir * clickForce);
        }
    
        /*  if (Vector3.Magnitude(transform.position - new Vector3 (mousePos.x, mousePos.y, 0)) < 6) 
        {
            rb.velocity = Vector2.zero; 
        }*/
    }
}