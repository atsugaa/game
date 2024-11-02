using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Variabel untuk menyimpan status pause
    public static bool isPaused = false;

    // Referensi ke UI Panel untuk menu pause
    public GameObject Paused;

    void Update()
    {
        // Cek jika pemain menekan tombol 'Escape' untuk pause atau resume
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    // Fungsi untuk mem-pause game
    public void Pause()
    {
        Time.timeScale = 0f;  // Menghentikan game
        isPaused = true;
        Paused.SetActive(true);  // Menampilkan menu pause
    }

    // Fungsi untuk melanjutkan game
    public void ResumeGame()
    {
        Time.timeScale = 1f;  // Melanjutkan game
        isPaused = false;
        Paused.SetActive(false);  // Menyembunyikan menu pause
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
