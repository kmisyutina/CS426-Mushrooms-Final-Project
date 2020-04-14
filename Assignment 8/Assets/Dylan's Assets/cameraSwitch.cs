using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    
    public int currentCamera = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCamera++;
            if (currentCamera > (cameras.Length - 1))
                currentCamera = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentCamera--;
            if (currentCamera < 0)
                currentCamera = (cameras.Length-1);
        }

        for(int i = 0; i < cameras.Length; i++)
        {
            if (i == currentCamera)
                cameras[i].enabled = true;
            else
                cameras[i].enabled = false;
        }
    }
}
