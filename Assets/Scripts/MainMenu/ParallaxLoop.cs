using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLoop : MonoBehaviour
{
    // Kecepatan background bergerak
    public float scrollSpeed = 2f;

    // Ukuran dari background untuk mengatur loop
    private float backgroundWidth;
    private Vector3 startPosition;
    void Start()
    {
        Time.timeScale = 1f;
        // Menyimpan posisi awal dan menghitung lebar background dari Sprite Renderer
        startPosition = transform.position;
        backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Menggerakkan background secara horizontal terus menerus
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, backgroundWidth);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}

