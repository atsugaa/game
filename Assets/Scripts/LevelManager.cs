using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LevelInstance;
    // Start is called before the first frame update
    void Awake() {
        if (LevelInstance == null) {
            LevelInstance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public async void Load()
    {
        
    }
}
