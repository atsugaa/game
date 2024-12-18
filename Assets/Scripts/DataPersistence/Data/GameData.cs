using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int health;
    public Vector2 playerPosition;
    public AttributesData playerAttributesData;

    public string sceneName;

    // the values defined in this constructor will be the default values
    // the game starts with when there's no data to load
    public GameData() 
    {
        health = 2;
        playerAttributesData = new AttributesData();
        sceneName = "laboratorium";
    }
}
