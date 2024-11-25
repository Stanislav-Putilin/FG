using UnityEngine;

public class ModalScript : MonoBehaviour
{
    private GameObject content;

    void Start()
    {
        content = transform.Find("Content").gameObject;
		Time.timeScale = content.activeInHierarchy ? 0.0f : 1.0f;
	}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
	}
}
