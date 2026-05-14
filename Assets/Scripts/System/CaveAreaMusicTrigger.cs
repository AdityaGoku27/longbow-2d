using UnityEngine;

public class CaveAreaMusicTrigger : MonoBehaviour
{
    public AudioSource mainAreaMusic;
    public AudioSource caveAreaMusic;

    public float loweredVolume = 0.3f;
    private float mainVolume;

    private void Start()
    {
        mainVolume = mainAreaMusic.volume;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainAreaMusic.volume = loweredVolume;
            caveAreaMusic.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mainAreaMusic.volume = mainVolume;
            caveAreaMusic.Stop();
        }
    }
}
