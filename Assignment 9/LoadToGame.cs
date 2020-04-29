using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadToGame : MonoBehaviour
{
    public Image black;
    public Animator anim;
    
    // Start is called before the first frame update
    public void OnClick()
    {
        if(!black.GetComponent<Image>().enabled)
        {
            black.GetComponent<Image>().enabled = true;
            StartCoroutine(LoadScene());
        }
        
    }

    IEnumerator LoadScene()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(0);
    }

}
