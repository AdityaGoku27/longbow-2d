using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public PlayerControls controls;
    public bool isPaused = false;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Player.Pause.performed += OnPausePressed;
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Pause.performed -= OnPausePressed;
        controls.Player.Disable();
    }

    private void OnPausePressed(InputAction.CallbackContext context)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        SFXManager.Instance.PlaySFX(SFXManager.Instance.uiButton);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void MainMenu()
    {
        SFXManager.Instance.PlaySFX(SFXManager.Instance.uiButton);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        SFXManager.Instance.PlaySFX(SFXManager.Instance.uiButton);
        Debug.Log("Quitting..");
        Application.Quit();
    }

}
