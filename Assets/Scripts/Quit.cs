﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Quit : MonoBehaviour {

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MenuStartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}