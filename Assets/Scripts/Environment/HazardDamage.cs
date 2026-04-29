using Unity.VisualScripting;
using UnityEngine;

public class HazardDamage : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
