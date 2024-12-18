using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMove : MonoBehaviour
{
    public int sceneBuildIndex;

    public GameObject theEndCanvas;

    void Start() {
        sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        print("Trigger Entered");

        if(other.tag == "Player") {
            if (sceneBuildIndex < 6) {
                SceneManager.LoadScene(sceneBuildIndex+1);
            } else {
                if (theEndCanvas != null)
                {
                    theEndCanvas.SetActive(true);
                    Time.timeScale = 0f; // Hentikan waktu
                }
                else
                {
                    Debug.LogWarning("The End Canvas tidak ditemukan di scene.");
                }
            }
        }
   }
}