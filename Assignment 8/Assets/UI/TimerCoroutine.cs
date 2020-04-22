using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerCoroutine : MonoBehaviour
{
    public Text timerText;
    public float maxTimeInSeconds;
    private float time;

    public AudioSource backgroundMusic;
    public AudioSource gameover;

    private int secondsPassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // call timer coroutine here
        StartCoroutine("StartTimer");
    }

    public IEnumerator StartTimer() {

        // for every second
        while (secondsPassed <= maxTimeInSeconds) {
            float time = (maxTimeInSeconds - secondsPassed);
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            Debug.Log("Timer: " + timeSpan.ToString(@"m\:ss"));
            timerText.text = timeSpan.ToString(@"m\:ss");
            yield return new WaitForSeconds(1.0f);
            secondsPassed++;
        }

        // time is up!
        backgroundMusic.Stop();
        gameover.Play(0);
    }
}
