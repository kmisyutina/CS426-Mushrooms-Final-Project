using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour
{
    public Text time;
    public int maxTime;
    public Text winOrLose;
    public Text countDown;
    
    int currentTime;

    public AudioSource backgroundMusic;
    public AudioSource gameOver;
    public AudioSource win;

    public Score scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        convertToSeconds(currentTime);
        StartCoroutine(UpdateTime());
    }

    IEnumerator UpdateTime()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            convertToSeconds(currentTime);

            if (scoreManager.score >= scoreManager.maxScore)
            {
                Time.timeScale = 0f;
                backgroundMusic.Stop();
                win.Play();
                winOrLose.text = "You win!";
                yield return new WaitUntil(() => !win.isPlaying);
                SceneManager.LoadScene(6);
            }
        }

        if (currentTime <= 0.0f && scoreManager.score < scoreManager.maxScore) 
        {
            Time.timeScale = 0f;
            backgroundMusic.Stop();
            gameOver.Play();
            winOrLose.text = "Game Over!";
            yield return new WaitUntil(() => !gameOver.isPlaying);
            SceneManager.LoadScene(6);
            
        } 
        
    }

    void convertToSeconds(int ct)
    {
        time.text = Mathf.Floor(ct / 60).ToString("00") + ":" + (ct % 60).ToString("00");
    }
}
