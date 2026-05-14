using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    private AudioSource audioSource;

    public AudioClip swordSlash;
    public AudioClip gameOver;
    public AudioClip playerHurt;
    public AudioClip uiButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
