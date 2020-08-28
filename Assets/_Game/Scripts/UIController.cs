using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameObject[] lives;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerController.lives == 2)
        {
            lives[2].SetActive(false);
        }
        else if (PlayerController.lives == 1)
        {
            lives[1].SetActive(false);
        }
        else if (PlayerController.lives == 0)
        {
            lives[0].SetActive(false);
        }
        else
        {

        }
    }
}
