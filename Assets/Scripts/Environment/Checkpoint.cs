using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public Sprite inactiveSprite;
    public Sprite activatedSprite;
    private SpriteRenderer sr;
    private bool activated = false;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = inactiveSprite; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerRespawn respawn = collision.GetComponent<PlayerRespawn>();

        if (!activated && respawn != null)
        {

            activated = true;

            respawn.SetCheckpoint(transform.position);

            sr.sprite = activatedSprite;

            Debug.Log("Checkpoint Reached");
        }
    }
}
