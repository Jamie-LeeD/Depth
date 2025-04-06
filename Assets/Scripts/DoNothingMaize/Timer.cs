using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private bool timerStart = true;
    public static bool timerEnd = false;

    private float currentTimer = 0;
    [SerializeField] private float timerDuration = 10f;

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
        //Debug.Log(currentTimer);
        if (Input.anyKey && !timerEnd)
        {
            ResetTimer();
        }
        if (timerStart)
        {
            currentTimer += Time.deltaTime;
            if(currentTimer >= timerDuration) 
            {
                timerEnd = true;
                timerStart = false;
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
