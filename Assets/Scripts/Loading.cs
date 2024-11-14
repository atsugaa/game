using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider progressBar;
    [SerializeField] private TextMeshProUGUI progressText;

    private bool loadingComplete = false;

    private void Start()
    {
        // Mulai loading scene yang dituju
        StartCoroutine(LoadAsyncScene(DataPersistenceManager.instance.getScene()));
    }

    private IEnumerator LoadAsyncScene(string sceneName)
    {
        loadingScreen.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (operation.progress >= 0.9f)
            {
                progressText.gameObject.SetActive(true);
                loadingComplete = true;
                yield break;  // Keluar dari coroutine setelah loading selesai
            }

            yield return null;
        }
    }

    private void Update()
    {
        // Menunggu pengguna menekan Enter setelah loading selesai
        if (loadingComplete && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(DataPersistenceManager.instance.getScene());
        }
    }
}
