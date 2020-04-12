using UnityEngine;

public class Food : MonoBehaviour
{
    public bool isEntered;
    public Score scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            isEntered = true;
            scoreManager.AddPoint();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Food")
        {
            isEntered = false;
            scoreManager.SubtractPoint();
        }
    }
}
