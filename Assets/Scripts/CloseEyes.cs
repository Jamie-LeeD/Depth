using System.Collections.Generic;
using UnityEngine;

public class CloseEyes : MonoBehaviour
{
    [SerializeField]
    GameObject eyelidsClosed;
    [SerializeField]
    GameObject eyelidsOpened;
    [SerializeField]
    List<Light> sceneLights = new List<Light>();

    bool closed;

    void Awake()
    {
        eyelidsClosed.SetActive(false);
        eyelidsOpened.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            closed = !closed;
            eyelidsClosed.SetActive(closed);
            eyelidsOpened.SetActive(!closed);
            foreach (Light light in sceneLights)
            {
                light.gameObject.SetActive(!closed);
            }
        }
    }
}
