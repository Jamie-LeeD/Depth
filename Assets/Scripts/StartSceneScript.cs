using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject MainMenuUI;
    GameObject OptionsUI;

    private void Start()
    {
        OptionsUI.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OptionsButton()
    {
        OptionsUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    public void BackButton()
    {
        OptionsUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
}
