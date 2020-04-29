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
    public void OnClick(int sceneNum)
    {
        if(!black.GetComponent<Image>().enabled)
        {
            black.GetComponent<Image>().enabled = true;
            StartCoroutine(LoadScene(sceneNum));
        }
        
    }

    IEnumerator LoadScene(int sceneNum)
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(sceneNum);
    }

}
