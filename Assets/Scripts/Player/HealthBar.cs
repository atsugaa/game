using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour, IDataPersistence
{
    public Slider slider;

    public GameObject GameOver;

    public int health;

    public void LoadData(GameData data) {
        health = data.health;
    }

    public void SaveData(GameData data) {
        data.health = health;
    }

    public void Update(GameData data) {
        slider.value = health;
        data.health = health;
    }

    public void TakeDamage(int damage) {
        health-=damage;
        if (health<=0) {
            health = 0;
            GameOver.SetActive(true);
        }
    }
}
