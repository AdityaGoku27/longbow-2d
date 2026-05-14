using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int maxLives = 3;
    public int currentLives;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentLives = maxLives;
        UpdateHeartUI();
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateHeartUI();

        if (currentLives > 0)
        {
            PlayerRespawn playerRespawn = FindFirstObjectByType<PlayerRespawn>();
            
            if (playerRespawn != null)
            {
                playerRespawn.Respawn();
            }
                
        }
        else
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
            SFXManager.Instance.PlaySFX(SFXManager.Instance.gameOver);
            gameOverPanel.SetActive(true);
        }
    }

    public void UpdateHeartUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        currentLives = maxLives;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuUI()
    {
        Time.timeScale = 1f;
        currentLives = maxLives;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGameUI()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
