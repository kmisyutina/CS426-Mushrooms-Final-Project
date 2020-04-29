using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public bool isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        if(BackgroundMusic.Instance != null)
        {
            Debug.Log("1");
        }
        if(BackgroundMusic.Instance != null && !BackgroundMusic.Instance.gameObject.GetComponent<AudioSource>().isPlaying)
        {
            Debug.Log("1 + 2");
            isPlaying = true;
            BackgroundMusic.Instance.gameObject.GetComponent<AudioSource>().Play();
        } else
        {
            isPlaying = false;
        }
    }
}
