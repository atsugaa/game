using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerContoller : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    Rigidbody2D rb;

    private Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.isPaused = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        if (!PauseMenu.isPaused) {
            //if movement input not 0, try to move
            if (movementInput != Vector2.zero) {
                bool success = TryMove(movementInput);
                animator.SetFloat("moveX", movementInput.x);
                animator.SetFloat("moveY", movementInput.y);
                animator.SetBool("moving", true);
                if (!success) {
                    success = TryMove(new Vector2(movementInput.x, 0));
                    if (!success) {
                        success = TryMove(new Vector2(0, movementInput.y));
                    }
                }
            } else {
                animator.SetBool("moving", false);
            }
        }
    }

    private bool TryMove(Vector2 direction) {
        //check for potential collision
        int count = rb.Cast(
            direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collision
            movementFilter, // the setting that determine when a collision can occur on such as layers to collide with
            castCollisions, // list of collision to store the found collision into after the cast is finished
            moveSpeed * Time.fixedDeltaTime + collisionOffset // the amount to cast equal to the movement plus an offset
        );
        
        if (count == 0) {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime); 
            return true;  
        } else {
            return false;
        }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}
