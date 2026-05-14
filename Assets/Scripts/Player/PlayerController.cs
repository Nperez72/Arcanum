using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed;
    Rigidbody2D rb;


    //DASHING LOGIC
    [SerializeField] float dashCoolDown;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;
    Boolean canDash = true;
    Boolean dashing = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //DASHING LOGIC
        if (Input.GetKeyDown(KeyCode.Space) && canDash) {
            StartCoroutine(Dash());
        }

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        //DASHING LOGIC
        if (dashing)
            return;

        rb.linearVelocity = moveInput * moveSpeed;
    }

    //DASHING LOGIC
    IEnumerator Dash() {
        dashing = true;
        canDash = false;
        rb.linearVelocity = moveInput * dashSpeed;
        yield return new WaitForSeconds(dashDuration);
        dashing = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }

}
