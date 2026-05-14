using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextLevelIndex);
            }
            else
            {
                Debug.Log("Game Complete!.. ");
            }
        }
    }
}
