using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 moveDirection;
    private string lastMoveDirection = "IdleRight"; // Predvolený smer státia

    public VectorValue startingPosition;

    void Update()
    {
        ProcessInputs();
    }

    void Start(){
        transform.position = startingPosition.initalValue;
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveDirection != Vector2.zero)
        {
            // Aktualizuje posledný smer pohybu podľa aktuálneho vstupu
            if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                lastMoveDirection = moveX > 0 ? "IdleRight" : "IdleLeft";
            }
            else
            {
                lastMoveDirection = moveY > 0 ? "IdleUp" : "IdleDown";
            }
            TriggerWalkAnimation(moveDirection);
        }
        else
        {
            TriggerIdleAnimation();
        }
    }

    void Move()
    {
        rb.velocity = moveDirection * moveSpeed;
    }

    void TriggerWalkAnimation(Vector2 direction)
    {
        ResetMovementTriggers();

        if (direction.x > 0)
            animator.SetTrigger("WalkRight");
        else if (direction.x < 0)
            animator.SetTrigger("WalkLeft");
        else if (direction.y > 0)
            animator.SetTrigger("WalkUp");
        else if (direction.y < 0)
            animator.SetTrigger("WalkDown");
    }

    void TriggerIdleAnimation()
    {
        ResetMovementTriggers();

        // Aktivuje správnu idle animáciu na základe posledného smeru pohybu
        animator.SetTrigger(lastMoveDirection);
    }

    void ResetMovementTriggers()
    {
        animator.ResetTrigger("WalkRight");
        animator.ResetTrigger("WalkLeft");
        animator.ResetTrigger("WalkUp");
        animator.ResetTrigger("WalkDown");
        // Resetuj tiež všetky idle triggery
        animator.ResetTrigger("IdleRight");
        animator.ResetTrigger("IdleLeft");
        animator.ResetTrigger("IdleUp");
        animator.ResetTrigger("IdleDown");
    }
}
