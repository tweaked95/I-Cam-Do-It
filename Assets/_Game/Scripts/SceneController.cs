using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject[] savedObjects;
    public GameObject winScreen;

    int sceneCounter;
    private void Awake()
    {
        foreach (GameObject obj in savedObjects)
        {
            DontDestroyOnLoad(obj);
        }
    }

    private void Start()
    {
        sceneCounter = 1;
    }

    private void Update()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name == "EndGame" || activeScene.name == "WinScreen")
        {
            foreach (GameObject obj in savedObjects)
            {
                Destroy(obj);
            }
        }
    }

    public void ChangeScene()
    {
        sceneCounter++;
        if (sceneCounter == 5)
        {
            print("failed");
        }
        else
        {
            SceneManager.LoadScene(sceneCounter);
        }
    }
}
