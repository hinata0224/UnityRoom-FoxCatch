using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public void GoMain()
    {
        SceneManager.LoadSceneAsync("Main");
    }
    public void GoClear()
    {
        SceneManager.LoadSceneAsync("Clear");
    }
    public void GoStart()
    {
        SceneManager.LoadSceneAsync("Start");
    }
}
