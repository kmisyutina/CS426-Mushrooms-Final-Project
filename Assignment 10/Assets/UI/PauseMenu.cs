using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject controlsImage;
    public AudioSource backgroundMusic;

    private float instructionsTimer = 8f;

    public bool isPaused = false;

    /* referenced YouTube video
     * TITLE: PAUSE MENU in Unity
     * By Brackeys               */
    void Start()
    {
        Time.timeScale = 1f;
        controlsImage.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (instructionsTimer > 0f)
        {
            instructionsTimer -= Time.deltaTime;
            if (instructionsTimer <= 0f)
            {
                controlsImage.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Debug.Log("Not Paused");
                isPaused = false;
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameIsPaused = false;
                backgroundMusic.Play();
            }
            else
            {
                Debug.Log("Paused");
                isPaused = true;
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameIsPaused = true;
                backgroundMusic.Pause();
            }
        }
    }
}
