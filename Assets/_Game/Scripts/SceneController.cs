using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject[] savedObjects;
    public string[] sceneList;

    static int currentScene;
    private void Awake()
    {
        foreach (GameObject obj in savedObjects)
        {
            DontDestroyOnLoad(obj);
        }
    }

    private void Start()
    {
        currentScene = 1;
    }

    public void ChangeScene()
    {
        currentScene++;
        if (currentScene == 2)
        {
            SceneManager.LoadScene(sceneList[currentScene]);
        }
        if (currentScene == 3)
        {
            SceneManager.LoadScene(sceneList[currentScene]);
        }
    }
}
