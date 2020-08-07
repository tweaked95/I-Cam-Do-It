using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    public Camera cam;

    Transform relativeTransform;
    int camValue;

    Vector3 localMoveInput;
    Vector3 rightWorldMovement;
    Vector3 forwardWorldMovement;
    Vector3 moveDirection;

    private void Start()
    {
    }
    void FixedUpdate()
    {
        camValue = cam.GetComponent<CamController>().currentCamera;
        relativeTransform = cam.GetComponent<CamController>().cameraList[camValue].transform;
        Debug.Log(relativeTransform.forward);
        if (camValue == 0)
        {
            MoveMainCam();
        }

        else if (camValue == 1 || camValue == 2)
        {
            MoveSideCam();
        }

    }

    void MoveMainCam()
    {
        localMoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        rightWorldMovement = relativeTransform.right;
        forwardWorldMovement = relativeTransform.forward;

        moveDirection = Vector3.ClampMagnitude(rightWorldMovement * localMoveInput.x + forwardWorldMovement * localMoveInput.z, 1);

        moveDirection.y = 0;

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
    }

    void MoveSideCam()
    {
        localMoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        moveDirection = Vector3.ClampMagnitude(rightWorldMovement * localMoveInput.x, 1);
        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed * Time.deltaTime);
    }
    
}
