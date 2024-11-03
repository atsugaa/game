using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play() {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    public void Quit() {
        Application.Quit();
    }
}