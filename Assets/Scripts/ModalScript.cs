using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalScript : MonoBehaviour
{
    private GameObject content;
	private GameObject contentStartInfo;
	private static GameObject contentGameOver;

	void Start()
    {
        content = transform.Find("Content").gameObject;
		contentStartInfo = transform.Find("ContentStartInfo").gameObject;
		contentGameOver = transform.Find("ContentGameOver").gameObject;

		Time.timeScale = contentStartInfo.activeInHierarchy ? 0.0f : 1.0f;
	}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !contentStartInfo.activeInHierarchy && !contentGameOver.activeInHierarchy)
        {
            Time.timeScale = content.activeInHierarchy ? 1.0f : 0.0f;
            content.SetActive(!content.activeInHierarchy);
        }
         
    }

    public void OnExitButtonClick()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

	public void OnResumeButtonClick()
	{
		Time.timeScale = 1.0f;
		content.SetActive(false);
		contentStartInfo.SetActive(false);
		contentGameOver.SetActive(false);
	}

    public void OnStartNewGameButtonClick() 
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public static void GameOver()
    {
		Time.timeScale = 0.0f;
		contentGameOver.SetActive(true);
	}
}
