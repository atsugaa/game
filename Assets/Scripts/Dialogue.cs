using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogBox;   // Referensi ke dialog box UI
    public TextMeshPro dialogText;        // Referensi ke Text di dialog box

    private string[] dialogLines;  // Array untuk menyimpan baris dialog
    private int currentLineIndex;  // Indeks baris dialog saat ini
    private bool isDialogActive;   // Untuk mengecek apakah dialog aktif


    void Start()
    {
        SetDialogByScene();
        currentLineIndex = 0;
        ShowDialog();
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (isDialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueDialog();
        }
    }


    void SetDialogByScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "laboratorium":
                dialogLines = new string[] {
                    "Chapter 1",
                    "Temukan pintu keluar dari ruangan ini."
                };
                break;
            case "desa":
                dialogLines = new string[] {
                    "Chapter 2",
                    "Temukan jalan keluar dari desa"
                };
                break;
            case "gua":
                dialogLines = new string[] {
                    "Chapter 3",
                    "SSSTTT... TIDAK ADA MONSTER DISINI"
                };
                break;
            case "hutan":
                dialogLines = new string[] {
                    "Chapter 4",
                    "Temukan gerbang pohon"
                };
                break;
            case "Pantai":
                dialogLines = new string[] {
                    "Last Chapter",
                    "Sudah saatnya..."
                };
                break;
            default:
                dialogLines = new string[] { "Selamat bermain!" };
                break;
        }
    }

    public void ShowDialog()
    {
        isDialogActive = true;
        dialogBox.SetActive(true);
        UpdateDialogText();
    }

    public void HideDialog()
    {
        isDialogActive = false;
        dialogBox.SetActive(false);
    }

    public void ContinueDialog()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogLines.Length)
        {
            UpdateDialogText();
        }
        else
        {
            HideDialog();
        }
    }

    private void UpdateDialogText()
    {
        dialogText.text = dialogLines[currentLineIndex];
    }
}
