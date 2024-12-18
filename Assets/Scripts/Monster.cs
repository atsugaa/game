using UnityEngine;
using Pathfinding;

public class Monster : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    private PlayerContoller playerController;
    public Transform player;
    private AIPath aiPath;
    private Animator animator;

    private void Start()
    {
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();

        // Mengambil PlayerController dari objek Player
        playerController = player.GetComponent<PlayerContoller>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController tidak ditemukan pada Player");
        }
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= aiPath.endReachedDistance)
        {
            aiPath.canMove = false;
            animator.SetBool("attack", true);

            if (Time.time - lastAttackTime >= attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            aiPath.canMove = true;
            animator.SetBool("attack", false);
        }
    }

    private void AttackPlayer()
    {
        if (playerController != null)
        {
            if (playerController.health <= 0) {
                playerController.health = 0;
                Time.timeScale = 0f;
            } else {
                playerController.health -= attackDamage;
            }
        }
    }
}
