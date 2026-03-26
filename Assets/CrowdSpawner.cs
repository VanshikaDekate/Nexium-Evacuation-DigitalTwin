using UnityEngine;

public class CrowdSpawner : MonoBehaviour
{
    public GameObject agentPrefab;
    public Transform[] exits;
    public int count = 30;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-10, 10),
                1,
                Random.Range(-10, 10)
            );

            GameObject agent = Instantiate(agentPrefab, pos, Quaternion.identity);
            agent.GetComponent<AgentController>().exits = exits;
        }
    }
}