using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (BackgroundMusic.Instance != null)
        {
            BackgroundMusic.Instance.gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
