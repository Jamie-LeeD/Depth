using UnityEngine;

public class CloseEyes : MonoBehaviour
{
    [SerializeField]
    GameObject eyelidsClosed;
    [SerializeField]
    GameObject eyelidsOpened;

    bool closed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) closed = !closed;
        eyelidsClosed.SetActive(closed);
        eyelidsOpened.SetActive(!closed);
    }
}
