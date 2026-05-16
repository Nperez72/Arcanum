using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      
        ApplyMovement();
    }

    /// <summary>
    /// Applies movement parameters to the animator to control the player's animations for movment and idle poses.
    /// </summary>
    void ApplyMovement()
    {
        bool isMoving = rb.linearVelocity.magnitude > 0.1f;
        anim.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            anim.SetFloat("velX", rb.linearVelocity.x);
            anim.SetFloat("velY", rb.linearVelocity.y);
            anim.SetFloat("idleX", rb.linearVelocity.x);
            anim.SetFloat("idleY", rb.linearVelocity.y);
        }
    }
}
