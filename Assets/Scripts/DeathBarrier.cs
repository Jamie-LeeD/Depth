using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField]
    Transform spawnPosition;
    [SerializeField]
    PlayerController player;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthManager.Instance.TakeDamage();
            player.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            player.gameObject.transform.position = spawnPosition.position;
        }
    }
}
