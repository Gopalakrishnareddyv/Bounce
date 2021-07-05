using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(2);
    }
}
