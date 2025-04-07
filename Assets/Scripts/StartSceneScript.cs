using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
    [SerializeField] private GameObject OptionsUI;
    [SerializeField] private GameObject ControlsUI;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        OptionsUI.SetActive(false);
        ControlsUI.SetActive(false);
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
        ControlsUI.SetActive(false);
        MainMenuUI.SetActive(false);
    }

    public void BackButton()
    {
        OptionsUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }

    public void XButton() 
    {
        ControlsUI.SetActive(false);
    }

    public void Controls()
    {
        ControlsUI.SetActive(true);
    }
}
