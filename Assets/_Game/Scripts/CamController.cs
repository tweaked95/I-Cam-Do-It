using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject[] cameraList;
    public int currentCamera;
    void Start()
    {
        currentCamera = 0;
        for (int i = 0; i < cameraList.Length; i++)
        {
            cameraList[0].gameObject.SetActive(false);
        }

        if (cameraList.Length > 0)
        {
            cameraList[0].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (currentCamera < cameraList.Length)
        {
            if (currentCamera == 0)
            {
                cameraList[currentCamera].gameObject.SetActive(true);
            }
            else
            {
                cameraList[currentCamera - 1].gameObject.SetActive(false);
                cameraList[currentCamera].gameObject.SetActive(true);
            }
        }
        else
        {
            currentCamera = 0;
            cameraList[currentCamera].gameObject.SetActive(true);
            cameraList[cameraList.Length - 1].gameObject.SetActive(false);
        }
    }
}
