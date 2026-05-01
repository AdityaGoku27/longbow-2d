using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float invincibleDuration = 1f;
    private bool isInvincible = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            return;
        }

        currentHealth -= damage;

        Debug.Log("Player took damage..");

        isInvincible = true;
        Invoke(nameof(ResetInvincibility), invincibleDuration);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void ResetInvincibility()
    {
        isInvincible = false;
    }

    private void Die()
    {
        Debug.Log("Player Died");
    }
}
