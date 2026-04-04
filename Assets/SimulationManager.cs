using UnityEngine;
using TMPro;

public class SimulationManager : MonoBehaviour
{
    public float simulationTime = 60f;
    private float currentTime;

    public TMP_Text timerText;

    void Start()
    {
        currentTime = simulationTime;
    }

    void Update()
    {
        Debug.Log("NEW SCRIPT RUNNING");

        currentTime -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(currentTime);
        }
    }
}