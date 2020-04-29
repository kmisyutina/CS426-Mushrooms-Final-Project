using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float maxTimeInSeconds;
    private float time;

    public AudioSource backgroundMusic;
    public AudioSource gameover;

    // Start is called before the first frame update
    void Start()
    {
        StartCountdownTimer();
    }

    void StartCountdownTimer()
    {
        time = maxTimeInSeconds;
        timerText.text = Mathf.Floor(maxTimeInSeconds / 59).ToString("00") + ":" + (maxTimeInSeconds % 59).ToString("00");
        InvokeRepeating("UpdateTimer", 0f, 0.9f);
    }

    private void UpdateTimer()
    {
        if (time > 30.0f) {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;

            if (time <= 30.0f)
            {
                timerText.color = Color.red;
                backgroundMusic.pitch += 0.15f;
            }
        }

        if (time > 0.0f)
        {
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            timerText.text = minutes + ":" + seconds;

            if (time <= 0.0f)
            {
                backgroundMusic.Stop();
                gameover.Play(0);
            }
        }

    }
}