using System;
using System.Collections.Generic;
using UnityEngine;

public class CloseEyes : MonoBehaviour
{
    [SerializeField]
    Material eyelidsClosed;
    [SerializeField]
    Material eyelidsOpened;
    [SerializeField]
    GameObject eyelids;
    [SerializeField]
    List<Light> sceneLights = new List<Light>();

    bool closed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            closed = !closed;
            eyelids.GetComponent<MeshRenderer>().material = closed ? eyelidsClosed : eyelidsOpened;
            Array.ForEach<Light>(sceneLights.ToArray(), l => l.gameObject.SetActive(!closed));
        }
    }
}
