using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        HealthManager.Instance.ResetHealth();
        SceneManager.LoadSceneAsync(0);
    }

    public void ExitGame()
    {
        Debug.Log("Exit");
    }
}
