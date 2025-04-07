using TMPro;
using UnityEngine;

public class TimerBoss : MonoBehaviour
{
    [SerializeField] private bool timerStart = true;
    public static bool timerEnd = false;

    private float currentTimer = 0f;
    [SerializeField] private float durationTimer = 20f;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnpoint;

    public TextMeshProUGUI outputTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerStart = true;
        timerEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStart)
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= durationTimer)
            {
                HealthManager.Instance.TakeDamage();
                player.transform.position = spawnpoint.position;
                ResetTimer();
            }
        }
        VisualUpdate();
    }
    private void ResetTimer()
    {
        currentTimer = 0;
        timerStart = true;
        timerEnd = false;
    }

    void VisualUpdate()
    {
        ConvertTimer();
        outputTime.text = currentTimer.ToString();
    }

    public void ConvertTimer()
    {
        currentTimer = Mathf.Round(currentTimer * 1000.0f) * 0.001f;
    }
}
