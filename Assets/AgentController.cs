using UnityEngine;

public class AgentController : MonoBehaviour
{
    public Transform[] exits;
    public float speed = 2f;

    public float detectionRadius = 3f;
    public float crowdCheckRadius = 3f;
    public float crowdPenaltyMultiplier = 2f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (exits == null || exits.Length == 0) return;

        Transform target = exits[0];
        float bestScore = float.MaxValue;

        // 🔵 OPTIMIZED EXIT SELECTION
        foreach (Transform ex in exits)
        {
            float dist = Vector3.Distance(transform.position, ex.position);

            Collider[] nearExit = Physics.OverlapSphere(ex.position, crowdCheckRadius);

            int crowdCount = 0;
            foreach (Collider col in nearExit)
            {
                AgentController other = col.GetComponent<AgentController>();

                if (other != null && other != this)
                {
                    crowdCount++;
                }
            }

            float score = dist + (crowdCount * crowdPenaltyMultiplier);

            if (score < bestScore)
            {
                bestScore = score;
                target = ex;
            }
        }

        // ✅ NOW we recompute distance to selected exit
        float minDist = Vector3.Distance(transform.position, target.position);

        Vector3 direction = (target.position - transform.position).normalized;

        float currentSpeed = speed;

        // 🔴 CONGESTION DETECTION
        Collider[] nearby = Physics.OverlapSphere(transform.position, detectionRadius);

        int count = 0;

        foreach (Collider col in nearby)
        {
            AgentController other = col.GetComponent<AgentController>();

            if (other != null && other != this)
            {
                count++;
            }
        }

        // 🔴 APPLY CONGESTION EFFECT
        if (count >= 3)
        {
            currentSpeed *= 0.5f;

            if (rend != null)
                rend.material.color = Color.red;
        }
        else
        {
            if (rend != null)
                rend.material.color = Color.white;
        }

        // 🔵 EXIT SLOWDOWN
        if (minDist < 3f)
        {
            currentSpeed *= 0.3f;
        }

        // 🚶 MOVEMENT
        transform.position += direction * currentSpeed * Time.deltaTime;
    }
}