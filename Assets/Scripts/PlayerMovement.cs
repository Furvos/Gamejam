using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public float clickForce = 1;
    public Position objPos;
    public float turnSpeed = 5f;

    public float dashMultiplier = 1f;
    public float dashSpeed = 2;
    public float dashDuration = 0.2f;
    private float dashTimer;

    Vector2 movement;
    Vector2 mousePos;
    public Position playerPos;

    private float _playerMouseDistance = 3;
    private float _interpolateAngleSpeed = 0.15f;

    // Update is called once per frame

    void StartDash()
    {
        dashMultiplier = dashSpeed;
        dashTimer = dashDuration;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        HandleDash();
    }

    private void HandleDash()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartDash();
        }

        if (dashTimer > 0)
        {
            dashTimer -= Time.deltaTime;
            if(dashTimer < 0)
            {
                dashTimer = 0;
                dashMultiplier = 1;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;

        rb.rotation = LearpAngle(rb.rotation, angle, _interpolateAngleSpeed);
        var mouseDir = (mousePos - rb.position).normalized;

        if (Input.GetMouseButton(0) && Mathf.Abs(Vector3.Distance(mousePos, transform.position)) > _playerMouseDistance)
        {
            rb.MovePosition(rb.position + mouseDir * clickForce * dashMultiplier);
            //rb.AddForce(mouseDir * clickForce * dashMultiplier);
        }else {
          rb.velocity = Vector2.zero;
        }

    
        /*  if (Vector3.Magnitude(transform.position - new Vector3 (mousePos.x, mousePos.y, 0)) < 6) 
        {
            rb.velocity = Vector2.zero; 
        }*/
    }

    private float LearpAngle(float startAngle, float angle, float interpolateValue)
    {
      return startAngle + interpolateValue * (angle - startAngle);
    }
}
