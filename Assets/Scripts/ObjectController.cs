using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Vector3 originalPositions;
    Vector3 tempPositionsTop;
    Vector3 tempPositionsSide;

    Vector3 offsetTop;
    Vector3 offsetSide;

    int tracker = 0;
    // Start is called before the first frame update
    void Start()
    {
        originalPositions = transform.position;
        tempPositionsSide = originalPositions;
        tempPositionsTop = originalPositions;

        offsetSide = originalPositions - tempPositionsSide;
        offsetTop = originalPositions - tempPositionsTop;
    }

    public void ChangeToSide()
    {
        tracker = 1;
        tempPositionsSide = new Vector3(0, tempPositionsSide.y, tempPositionsSide.z);
        transform.position = tempPositionsSide;
    }

    public void ChangeToTop()
    {
        tracker = 2;
        tempPositionsTop = new Vector3(tempPositionsTop.x, 0, tempPositionsTop.z);
        transform.position = tempPositionsTop;
    }

    public void ChangeToMain()
    {
        transform.position = originalPositions;
        tracker = 0;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (tracker == 1)
            {
                Debug.Log(offsetSide);
                collision.gameObject.transform.position += offsetSide;
            }

            if (tracker == 2)
            {
                collision.gameObject.transform.position += offsetTop;
            }
        }
    }
}
