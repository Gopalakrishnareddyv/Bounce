using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    public GameObject main;
    public GameObject options;
    public GameObject settings;

    public void NextScene()
    {
        SceneManager.LoadScene(0);
    }
    public void Main()
    {
        main.SetActive(true);
        options.SetActive(false);
        settings.SetActive(false);
    }
    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
        settings.SetActive(false);
    }
    public void Settings()
    {
        main.SetActive(false);
        options.SetActive(false);
        settings.SetActive(true);
    }
}
