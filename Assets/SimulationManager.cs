using UnityEngine;
using UnityEngine.UI;

public class SimulationManager : MonoBehaviour
{
    public float timer = 0f;
    public bool isRunning = true;

    public Text timerText;

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F2");
        }
    }

    public void ResetTimer()
    {
        timer = 0f;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void StartTimer()
    {
        isRunning = true;
    }
}