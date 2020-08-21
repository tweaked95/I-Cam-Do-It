﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Vector3 originalPositions;
    Vector3 tempPositionsTop;
    Vector3 tempPositionsSide;

    public Vector3 offset;
    Vector3 offsetTop;
    Vector3 offsetSide;

    [SerializeField]
    int camValue;
    public Camera cam;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        originalPositions = transform.position;
        tempPositionsSide = new Vector3(0, originalPositions.y, originalPositions.z);
        tempPositionsTop = new Vector3(originalPositions.x, 0, originalPositions.z);

        offsetSide = originalPositions - tempPositionsSide;
        offsetTop = originalPositions - tempPositionsTop;

    }

    private void FixedUpdate()
    {
        camValue = cam.GetComponent<CamController>().currentCamera;
        if (camValue == 0)
        {
            ChangeToMain();
        }
        else if (camValue == 1 || camValue == 2)
        {
            ChangeToSide();
        }
        else if (camValue == 3)
        {
            ChangeToTop();
        }
    }
    public void ChangeToMain()
    {
        transform.position = originalPositions;
        offset = Vector3.zero;
    }

    public void ChangeToSide()
    {
        tempPositionsSide = new Vector3(0, tempPositionsSide.y, tempPositionsSide.z);
        transform.position = tempPositionsSide;
        Debug.Log("Side offset for " + offsetSide);
        offset = offsetSide;
    }

    public void ChangeToTop()
    {
        tempPositionsTop = new Vector3(tempPositionsTop.x, 0, tempPositionsTop.z);
        transform.position = tempPositionsTop;
        Debug.Log("Top offset for " + offsetTop);
        offset = offsetTop;
    }


}
