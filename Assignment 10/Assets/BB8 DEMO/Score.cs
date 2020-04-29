using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int maxScore = 5;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = score + "/" + maxScore;
    }

    public void AddPoint()
    {
        score++;

        if (score < maxScore)
            scoreText.text = score + "/" + maxScore;
        else
        {
            scoreText.text = maxScore + "/" + maxScore;
        }
    }

    public void SubtractPoint()
    {
        score--;

        if (score >= 0)
            scoreText.text = score + "/" + maxScore;
        else
            scoreText.text = 0 + "/" + maxScore;
    }
}