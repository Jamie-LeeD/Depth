using UnityEngine;

public class Ground : MonoBehaviour
{
    private GroundSpawner groundspawner;


    private void Awake()
    {
        groundspawner = GameObject.FindFirstObjectByType<GroundSpawner>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        groundspawner.spawnGround();
        //Destroy(gameObject, 10f);
    }
}
