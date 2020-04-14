using UnityEngine;

public class Food : MonoBehaviour
{
    public bool isEntered;
    public Score scoreManager;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            scoreManager.AddPoint();
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Food")
        {
            scoreManager.SubtractPoint();
        }
    }
}
