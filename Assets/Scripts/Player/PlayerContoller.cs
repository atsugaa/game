using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour, IDataPersistence
{
    public Slider HealthBar;

    public GameObject GameOver;
    public int health;
    public float moveSpeed = 1f;
    public Transform flashlightTransform;
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

    public void LoadData(GameData data) 
    {
        if (data.health != 0) {
            if (data.playerPosition.x != 0.0 && data.playerPosition.y != 0.0) {
                this.transform.position = data.playerPosition;
                SetFlashlightDirection(data.playerPosition);
            } else {
                SetFlashlightDirection(this.transform.position);
            }
            health = data.health;
        } else {
            health = 2;
        }
    }

    public void SaveData(GameData data) 
    {
        if (data.sceneName != SceneManager.GetActiveScene().name) {
            data.playerPosition.x = 0.0f;
            data.playerPosition.y = 0.0f;
            data.sceneName = SceneManager.GetActiveScene().name;
        } else {
            data.playerPosition = this.transform.position;
        }
        data.health = health;
    }

    // Update is called once per frame
    private void Update() {
        HealthBar.value = health;
        if (health<=0) {
            health = 0;
            GameOver.SetActive(true);
        }
        if (!PauseMenu.isPaused) {
            //if movement input not 0, try to move
            if (movementInput != Vector2.zero) {
                bool success = TryMove(movementInput);
                animator.SetFloat("moveX", movementInput.x);
                animator.SetFloat("moveY", movementInput.y);
                animator.SetBool("moving", true);
                // Rotasi senter mengikuti arah utama
                SetFlashlightDirection(movementInput);
                
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

    private void SetFlashlightDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            flashlightTransform.rotation = Quaternion.Euler(0, 0, 270); // Kanan
        }
        else if (direction.x < 0)
        {
            flashlightTransform.rotation = Quaternion.Euler(0, 0, 90); // Kiri
        }
        else if (direction.y > 0)
        {
            flashlightTransform.rotation = Quaternion.Euler(0, 0, 0); // Atas
        }
        else if (direction.y < 0)
        {
            flashlightTransform.rotation = Quaternion.Euler(0, 0, 180); // Bawah
        }
    }

    private void RotateFlashlightTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionToMouse = mousePosition - flashlightTransform.position;
        directionToMouse.z = 0; // Pastikan ini tetap di bidang 2D

        // Membuat quaternion yang mengarah ke posisi mouse
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToMouse);
        flashlightTransform.rotation = targetRotation;
    }

}
