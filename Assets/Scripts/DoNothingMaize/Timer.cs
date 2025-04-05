using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private bool timerStart = true;
    public static bool timerEnd = false;

    private float currentTimer = 0;
    [SerializeField] private float timerDuration = 10f;
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

    }

    private void ResetTimer()
    {
        currentTimer = 0;
        timerStart = true;
        timerEnd = false;
    }
}
