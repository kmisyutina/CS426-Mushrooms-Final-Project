﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public Score scoreManager;
    public bool isEntered = false;

    private void addPointToGoal()
    {
        scoreManager.AddPoint();
    }
}
