using Unity.VisualScripting;
using UnityEngine;

public class BossFallOff : MonoBehaviour
{
    [SerializeField] private Transform spawnpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = spawnpoint.position;
        HealthManager.Instance.TakeDamage();
    }
}
