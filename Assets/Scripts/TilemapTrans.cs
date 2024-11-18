using UnityEngine;
using UnityEngine.Tilemaps;

public class DynamicTileSorting : MonoBehaviour
{
    public Tilemap tilemap;  // Referensi ke Tilemap
    public Transform player;  // Referensi ke objek pemain
    public float detectionRadius = 1f; // Jarak deteksi kolisi antara pemain dan tile

    private GameObject[] tileObjects;  // Array untuk menyimpan objek tile yang dihasilkan
    private SpriteRenderer[] spriteRenderers;  // Array untuk menyimpan SpriteRenderer dari setiap tile

    void Start()
    {
        // Nonaktifkan Tilemap Renderer agar tidak terjadi duplikasi render
        tilemap.GetComponent<TilemapRenderer>().enabled = false;

        // Tambahkan SpriteRenderers untuk setiap tile
        AddSpriteRenderersToTiles();
    }

    // Fungsi untuk menambahkan SpriteRenderer ke setiap tile dalam Tilemap
    void AddSpriteRenderersToTiles()
    {
        BoundsInt bounds = tilemap.cellBounds;
        int count = 0;
        
        // Hitung jumlah tile yang ada
        foreach (var position in bounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(position);
            if (tile != null)
            {
                count++;
            }
        }

        tileObjects = new GameObject[count];
        spriteRenderers = new SpriteRenderer[count];
        int index = 0;

        // Buat GameObject dan SpriteRenderer untuk setiap tile
        foreach (var position in bounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(position);
            if (tile != null)
            {
                // Buat GameObject untuk tile
                GameObject tileObject = new GameObject("Tile_" + position);
                tileObject.transform.SetParent(tilemap.transform);
                tileObject.transform.position = tilemap.CellToWorld(position);

                // Tambahkan SpriteRenderer ke objek tile
                SpriteRenderer spriteRenderer = tileObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = tilemap.GetSprite(position);
                spriteRenderer.sortingLayerName = "Default";  // Sesuaikan dengan sorting layer yang diinginkan
                tileObjects[index] = tileObject;
                spriteRenderers[index] = spriteRenderer;
                index++;
            }
        }
    }

    // Update untuk memperbarui sorting order berdasarkan posisi pemain
    void Update()
    {
        // Deteksi tile yang berada dalam jangkauan atau bertabrakan dengan pemain
        foreach (GameObject tileObject in tileObjects)
        {
            SpriteRenderer spriteRenderer = tileObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Hitung jarak antara pemain dan tile
                float distance = Vector2.Distance(player.position, tileObject.transform.position);

                // Hanya perbarui sorting order jika tile berada dalam jarak tertentu (misalnya detectionRadius)
                if (distance < detectionRadius)
                {
                    // Menentukan sorting berdasarkan posisi Y objek dan pemain
                    spriteRenderer.sortingOrder = Mathf.FloorToInt(player.position.y - tileObject.transform.position.y);
                    // Debugging
                    Debug.Log($"Tilemap {gameObject.name} sorting order: {spriteRenderer.sortingOrder}");
                }
                // Debugging
                Debug.Log($"name {gameObject.name} distance {distance}, rad {detectionRadius}");
            }
        }
    }
}
