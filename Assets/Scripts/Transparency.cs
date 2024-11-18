using UnityEngine;

public class DynamicSorting : MonoBehaviour
{
    public Transform player; // Referensi ke objek pemain
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player != null && spriteRenderer != null)
        {
            // Tentukan sorting order berdasarkan posisi Y objek dan pemain
            if (player.position.y > transform.position.y)
            {
                // Jika pemain berada di atas objek, objek di belakang pemain
                spriteRenderer.sortingOrder = 1;  // Pemain di depan, objek di belakang
            }
            else
            {
                // Jika pemain berada di bawah objek, objek di depan pemain
                spriteRenderer.sortingOrder = -1;  // Pemain di belakang, objek di depan
            }
        }
    }
}
