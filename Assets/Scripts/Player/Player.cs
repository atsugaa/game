using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 100;

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;

        SceneManager.LoadScene("SampleScene");
    }
}
