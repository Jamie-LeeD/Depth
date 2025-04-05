using UnityEngine;

public class CloseEyes : MonoBehaviour
{
    [SerializeField]
    GameObject eyelids;

    bool closed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) closed = !closed;
        eyelids.SetActive(closed);
    }
}
