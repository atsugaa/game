using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button StartButton;
    [SerializeField] private Button LoadButton;

    private void Start() 
    {
        if (!DataPersistenceManager.instance.HasGameData()) 
        {
            LoadButton.interactable = false;
        }
    }
    // Start is called before the first frame update
    public void Play() {
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadScene("LoadingScreen");
    }

    public void Load() {
        DataPersistenceManager.instance.SaveGame();
        DataPersistenceManager.instance.LoadGame();
        SceneManager.LoadScene("LoadingScreen");
    }

    // Update is called once per frame
    public void Quit() {
        Application.Quit();
    }
}
