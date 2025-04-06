using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject controlsPanel;
    public GameObject SavePanel;
    public GameObject LoadPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            if(pausePanel.activeSelf) 
            {
                Continue(); 
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Controls()
    {
        Debug.Log("clicked");
        controlsPanel.SetActive(true);
        SavePanel.SetActive(false);
        LoadPanel.SetActive(false);
    }

    public void SaveBtn()
    {
        controlsPanel.SetActive(false);
        SavePanel.SetActive(true);
        LoadPanel.SetActive(false);
    }

    public void LoadBtn()
    {
        controlsPanel.SetActive(false);
        SavePanel.SetActive(false);
        LoadPanel.SetActive(true);
    }
}
