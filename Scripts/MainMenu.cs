using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("AG_scence_theatre");
    }

    public void QuitGame()
    {
        Debug.Log("Oyun kapatýldý");
        Application.Quit();
    }

    public void ShowHelp()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
