using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int PlayerHealth;

    public GameData() {
        this.PlayerHealth = 100;
    }
}
