using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    public void OnClick(int level)
    {
        SceneManager.LoadScene(level);
    }
}
