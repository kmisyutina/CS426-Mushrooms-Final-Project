using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float maxTimeInSeconds;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCountdownTimer();
    }

    void StartCountdownTimer()
    {
        time = maxTimeInSeconds;
        timerText.text = Mathf.Floor(maxTimeInSeconds / 60).ToString("00") + ":" + (maxTimeInSeconds % 60).ToString("00");
        InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
    }

    private void UpdateTimer()
    {
        time -= Time.deltaTime;
        string minutes = Mathf.Floor(time / 60).ToString("00");
        string seconds = (time % 60).ToString("00");
        timerText.text = minutes + ":" + seconds;
    }
}