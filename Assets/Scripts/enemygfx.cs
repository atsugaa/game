using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class enemygfx : MonoBehaviour
{
    public AIPath path;
    public Animator animator;
    void Start () {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (path.velocity.magnitude < 0.01f) {
            animator.SetBool("moving", false);
        } else {
            animator.SetBool("moving", true);
        }
        Vector3 currentScale = transform.localScale;
        if (path.desiredVelocity.x >= 0.01f && currentScale.x < 0) {
            currentScale.x = Mathf.Abs(currentScale.x); // Pastikan x selalu positif
            transform.localScale = currentScale;
        } else if (path.desiredVelocity.x <= -0.01f && currentScale.x > 0) {
            currentScale.x = -Mathf.Abs(currentScale.x); // Pastikan x selalu negatif
            transform.localScale = currentScale;
        }
    }

}
