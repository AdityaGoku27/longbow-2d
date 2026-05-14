using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float invincibleDuration = 1f;
    private bool isInvincible = false;
    public TextMeshProUGUI hpText;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHPUI();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {
            return;
        }

        currentHealth -= damage;
        SFXManager.Instance.PlaySFX(SFXManager.Instance.playerHurt);

        UpdateHPUI();

        Debug.Log("Player took damage..");

        isInvincible = true;
        Invoke(nameof(ResetInvincibility), invincibleDuration);

        if (currentHealth <= 0)
        {
            GameManager.Instance.LoseLife();
        }
    }

    private void ResetInvincibility()
    {
        isInvincible = false;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHPUI();
    }

    private void UpdateHPUI()
    {
        hpText.text = "HP - " + currentHealth;
    }
}
