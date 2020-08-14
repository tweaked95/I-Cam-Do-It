using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    public Camera cam;

    Transform relativeTransform;
    [SerializeField]
    GameObject[] groundElements;
    
    int camValue;

    Vector3 localMoveInput;
    Vector3 rightWorldMovement;
    Vector3 forwardWorldMovement;
    Vector3 moveDirection;

    private void Start()
    {
        groundElements = GameObject.FindGameObjectsWithTag("Ground");
    }
    void FixedUpdate()
    {
        camValue = cam.GetComponent<CamController>().currentCamera;
        if (camValue == 0)
        {
            MainCam();
            for (int i = 0; i < groundElements.Length; i++)
            {
                groundElements[i].GetComponent<ObjectController>().ChangeToMain();
            }
        }

        else if (camValue == 1 || camValue == 2)
        {
            SideCam();
            for (int i = 0; i < groundElements.Length; i++)
            {
                groundElements[i].GetComponent<ObjectController>().ChangeToSide();
            }
        }

        else if (camValue == 3)
        {
            TopCam();
            for (int i = 0; i < groundElements.Length; i++)
            {
                groundElements[i].GetComponent<ObjectController>().ChangeToTop();
            }
        }
    }

    void MainCam()
    {
        if (cam.orthographic)
        {
            cam.orthographic = false;
        }

        localMoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        relativeTransform = cam.transform;
        rightWorldMovement = relativeTransform.right;
        forwardWorldMovement = relativeTransform.forward;

        moveDirection = Vector3.ClampMagnitude(rightWorldMovement * localMoveInput.x + forwardWorldMovement * localMoveInput.z, 1);
        moveDirection.y = 0;

        Movement(moveDirection);
    }

    void SideCam()
    {
        if (!cam.orthographic)
        {
            cam.orthographic = true;
        }
        localMoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        relativeTransform = cam.transform;
        rightWorldMovement = relativeTransform.right;
        moveDirection = Vector3.ClampMagnitude(rightWorldMovement * localMoveInput.x, 1);
        Movement(moveDirection);
    }

    void TopCam()
    {
        localMoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        relativeTransform = cam.transform;
        rightWorldMovement = relativeTransform.right;
        forwardWorldMovement = relativeTransform.up;

        moveDirection = Vector3.ClampMagnitude(rightWorldMovement * localMoveInput.x + forwardWorldMovement * localMoveInput.z, 1);
        moveDirection.y = 0;

        Movement(moveDirection);

    }

    void Movement(Vector3 moveDirection)
    {
        transform.position += moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

        if (moveDirection != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.fixedDeltaTime);
    }


}
