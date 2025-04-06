using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject doorMesh;
    private bool doorOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doorOpen)
        {
            if(Input.GetKeyDown(KeyCode.E)) 
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        doorMesh.transform.Rotate(0, 90,0);
        doorOpen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        doorMesh.transform.Rotate(0, -90, 0);
    }


}
