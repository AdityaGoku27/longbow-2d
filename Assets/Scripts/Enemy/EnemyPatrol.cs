using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 2f;

    private Transform targetPoint;

    private EnemyDetection detection;

    private void Start()
    {
        targetPoint = pointB;
        detection = GetComponent<EnemyDetection>();
    }

    private void Update()
    {

        if (detection != null && detection.playerDetected && detection.playerTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, detection.playerTarget.position, patrolSpeed * Time.deltaTime);

            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(targetPoint.position.x, targetPoint.position.y)) < 0.1f)
        {
            if (targetPoint == pointB)
            {
                targetPoint = pointA;
            }
            else
            {
                targetPoint = pointB;
            }
        }

        if (targetPoint.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(8.7f, 7.6f, 1f);
        }
        else
        {
            transform.localScale = new Vector3(-8.7f, 7.6f, 1f);
        }
    }
}
