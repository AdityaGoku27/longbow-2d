using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    public Slider volumeSlider;

    public void PlayGame()
    {
        SFXManager.Instance.PlaySFX(SFXManager.Instance.uiButton);
        SceneManager.LoadScene("Level_01");
    }

    public void QuitGame()
    {
        Debug.Log("Game Quiting..");
        SFXManager.Instance.PlaySFX(SFXManager.Instance.uiButton);
        Application.Quit();
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        SFXManager.Instance.PlaySFX(SFXManager.Instance.uiButton);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        SFXManager.Instance.PlaySFX(SFXManager.Instance.uiButton);
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
