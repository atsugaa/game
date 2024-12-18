using UnityEngine;

public class monsterTrans : MonoBehaviour
{
    public Transform monster;                 // Referensi ke pemain
    public Transform player;
    public float detectionRadius;       // Jarak radius deteksi
    private SpriteRenderer spriteRenderer;   // SpriteRenderer monster
    
    void Start()
    {
        // Mendapatkan komponen SpriteRenderer dari monster
        spriteRenderer = monster.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (monster != null && spriteRenderer != null)
        {
            float distance = Vector2.Distance(transform.position, monster.position);

            if (distance <= detectionRadius)
            {
                if (monster.position.y > transform.position.y)
                {
                    if (monster.position.y > player.position.y) {
                        spriteRenderer.sortingOrder = -2;
                    } else {
                        spriteRenderer.sortingOrder = -1;
                    }
                }
                else
                {
                    if (monster.position.y < player.position.y) {
                        spriteRenderer.sortingOrder = 2;
                    } else {
                        spriteRenderer.sortingOrder = 1;
                    }
                }
            }
        }
    }

}
