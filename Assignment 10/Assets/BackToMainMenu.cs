using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public Text text;
    public Text countDown;

    // Update is called once per frame
    void Update()
    {
        if(text.text == "4/4")
        {
            StartCoroutine(BackToMain());
        }
    }

    IEnumerator BackToMain()
    {
        
        countDown.text = 5.ToString();
        yield return new WaitForSeconds(1f);
        countDown.text = 4.ToString();
        yield return new WaitForSeconds(1f);
        countDown.text = 3.ToString();
        yield return new WaitForSeconds(1f);
        countDown.text = 2.ToString();
        yield return new WaitForSeconds(1f);
        countDown.text = 1.ToString();
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(0);
    }
}
