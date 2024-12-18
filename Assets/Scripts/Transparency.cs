using UnityEngine;

public class Transparency : MonoBehaviour
{
    public Transform player;                 // Referensi ke pemain
    public Transform monster;
    public float detectionRadius;       // Jarak radius deteksi
    private SpriteRenderer spriteRenderer;   // SpriteRenderer monster
    
    void Start()
    {
        // Mendapatkan komponen SpriteRenderer dari monster
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player != null && spriteRenderer != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            float distance2 = Vector2.Distance(monster.position, player.position);

            if (distance <= detectionRadius)
            {
                if (player.position.y > transform.position.y)
                {
                    if (distance2 <= detectionRadius) {
                        if (player.position.y >= monster.position.y) {
                            spriteRenderer.sortingOrder = -2;
                        } else {
                            spriteRenderer.sortingOrder = -1;
                        }
                    } else {
                        spriteRenderer.sortingOrder = -1;
                    }
                }
                else
                {
                    if (distance2 <= detectionRadius) {
                        if (player.position.y <= monster.position.y) {
                            spriteRenderer.sortingOrder = 2;
                        } else {
                            spriteRenderer.sortingOrder = 1;
                        }
                    } else {
                        spriteRenderer.sortingOrder = 1;
                    }
                }
            } else {
                if (distance2 <= detectionRadius) {
                    if (player.position.y > monster.position.y) {
                        spriteRenderer.sortingOrder = -2;
                    } else {
                        spriteRenderer.sortingOrder = 2;
                    }
                }
            }
        }
    }

}
