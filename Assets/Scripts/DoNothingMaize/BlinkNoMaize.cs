using UnityEngine;

public class BlinkNoMaize : MonoBehaviour
{
    public GameObject blinkPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blinkPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) 
        {
            if(blinkPanel.activeSelf)
            {
                blinkPanel.SetActive(false);
            }
            else
            {
                blinkPanel.SetActive(true);
            }
        }
    }
}
