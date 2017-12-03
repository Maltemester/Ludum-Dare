using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIH2O : MonoBehaviour {

    public float h2oLeft = 100;
    [SerializeField]float reat = 1;

    [SerializeField] Image h2oImage;
    [SerializeField] GameObject deadText;

    void Start ()
    {
        Time.timeScale = 1;
    }

    void Update ()
    {
        h2oLeft -= Time.deltaTime * reat;

        h2oImage.fillAmount = h2oLeft / 100;

        Dead();
    }

    void Dead()
    {
        if (h2oLeft <= 0)
        {
            deadText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void StarScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void MenuScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
