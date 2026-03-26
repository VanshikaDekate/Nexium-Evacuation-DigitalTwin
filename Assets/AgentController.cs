using UnityEngine;

public class AgentController : MonoBehaviour
{
    public Transform[] exits;
    public float speed = 2f;

    void Update()
    {
        if (exits == null || exits.Length == 0) return;

        Transform target = exits[0];
        float minDist = Vector3.Distance(transform.position, exits[0].position);

        foreach (Transform ex in exits)
        {
            float dist = Vector3.Distance(transform.position, ex.position);
            if (dist < minDist)
            {
                minDist = dist;
                target = ex;
            }
        }

        Vector3 direction = (target.position - transform.position).normalized;

        float currentSpeed = speed;

        if (minDist < 3f)
        {
            currentSpeed *= 0.3f;
        }

        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}