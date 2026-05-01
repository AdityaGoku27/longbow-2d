using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int scoreValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScore playerScore = collision.GetComponent<PlayerScore>();

        if (playerScore != null)
        {
            playerScore.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
