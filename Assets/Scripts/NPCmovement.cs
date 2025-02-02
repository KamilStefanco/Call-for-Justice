using System.Collections.Generic;
using UnityEngine;

public class NPCPatrolMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public float moveSpeed = 5f;
    private int waypointIndex = 0;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        MoveToNextWaypoint();
    }

    void Update()
    {
        if (Vector2.Distance(rb.position, waypoints[waypointIndex].position) < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Count;
            MoveToNextWaypoint();
        }

        // Set animation parameters
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetBool("IsMoving", true);
    }

    void FixedUpdate()
    {
        // Move the NPC
        Vector2 newPosition = Vector2.MoveTowards(rb.position, waypoints[waypointIndex].position, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Count == 0)
            return;

        Vector2 direction = (waypoints[waypointIndex].position - transform.position).normalized;
        movement = direction;
    }
}
