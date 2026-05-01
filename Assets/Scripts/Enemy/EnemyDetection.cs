using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public bool playerDetected = false;

    public Transform playerTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<PlayerMovement>() != null)
        {
            playerDetected = true;
            playerTarget = collision.transform;
            Debug.Log("Player Detected");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>() != null)
        {
            playerDetected = false;
            Debug.Log("Player Lost");
        }
    }
}
