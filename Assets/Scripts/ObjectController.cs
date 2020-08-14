using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Vector3 originalPositions;
    Vector3 tempPositionsTop;
    Vector3 tempPositionsSide;
    // Start is called before the first frame update
    void Start()
    {
        originalPositions = transform.position;
        tempPositionsSide = originalPositions;
        tempPositionsTop = originalPositions;
    }

    public void ChangeToSide()
    {
        tempPositionsSide = new Vector3(0, tempPositionsSide.y, tempPositionsSide.z);
        transform.position = tempPositionsSide;
    }

    public void ChangeToTop()
    {
        tempPositionsTop = new Vector3(tempPositionsTop.x, 0, tempPositionsTop.z);
        transform.position = tempPositionsTop;
    }

    public void ChangeToMain()
    {
        transform.position = originalPositions;
    }
}
