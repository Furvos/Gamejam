using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public int clickForce = 200;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;

    Vector2 movement;
    Vector2 mousePos;
    private bool isDashing = false; //declara que é falsa só no void Start
    private float dashStartTime;

    private float _playerMouseDistance = 3;
    private float _interpolateAngleSpeed = 0.15f;

    private Vector2 lastClickPosition;
    private float lastClickTime = -Mathf.Infinity;

    private Vector2 lastMoveDirection;

    private float LerpAngle(float startAngle, float angle, float interpolateValue)
    {
        return startAngle + interpolateValue * (angle - startAngle);
    }

    void StartDash()
    {
        isDashing = true;
        dashStartTime = Time.time;
        dashSpeed *= moveSpeed * Time.deltaTime ;
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastClickTime < 0.2f) //não verifica a partir do lastClick, mas a partir do fim do último dash! ele pode durar mais que os 0.2f decorridos do lastclick
            {
                StartDash();
            }
            else
            {
                lastClickTime = Time.time;
                lastClickPosition = mousePos;
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = LerpAngle(rb.rotation, angle, _interpolateAngleSpeed);
        var mouseDir = mousePos - rb.position;


        if (Input.GetMouseButton(0) && Mathf.Abs(Vector3.Distance(mousePos, transform.position)) > _playerMouseDistance)
        {
            
            rb.AddForce(mouseDir * clickForce);

            
            lastMoveDirection = mouseDir.normalized;
        }
        else
        {
            rb.velocity = Vector2.zero;
            lastMoveDirection = movement.normalized;
        }

        if (!isDashing)
        {
            Vector2 moveDir = (lastClickPosition - (Vector2)transform.position).normalized;
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            if (Time.time - dashStartTime <= dashDuration)
            {
                rb.MovePosition(rb.position + movement * dashSpeed * Time.fixedDeltaTime);
            }
            else
            {
                isDashing = false;
            }
        }

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(lastMoveDirection.y, lastMoveDirection.x) * Mathf.Rad2Deg - 90f);
        rb.rotation = LerpAngle(rb.rotation, targetRotation.eulerAngles.z, _interpolateAngleSpeed);
    }

   

}
