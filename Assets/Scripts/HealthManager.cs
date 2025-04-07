using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    public bool isDead = false;


    private void Awake()
    {
        // Singleton pattern: keep only one instance
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) 
        {
            SceneManager.LoadSceneAsync(6);
        }
    }

    public void TakeDamage()
    {
        if(isDead) return;

        currentHealth--;
        
        if (currentHealth <= 0) 
        {
            isDead = true;
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }
}
