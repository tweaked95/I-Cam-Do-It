using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public static int lives;

    public Camera cam;

    Transform relativeTransform;
    [SerializeField]
    GameObject[] groundElements;

    int camValue;
    RaycastHit hit;

    Vector3 localMoveInput;
    Vector3 rightWorldMovement;
    Vector3 forwardWorldMovement;
    Vector3 moveDirection;

    GameObject offsetObject;


    private void Start()
    {
        groundElements = GameObject.FindGameObjectsWithTag("Ground");
        lives = 3;
    }
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5))
        {
            if (hit.collider.gameObject.CompareTag("KillVolume"))
            {
                transform.position = Vector3.zero + new Vector3(0,3,0);
                lives--;
                Debug.Log(lives);
            }

            else if (hit.collider.gameObject.CompareTag("Ground"))
            {
                offsetObject = hit.collider.gameObject;
                Debug.Log(offsetObject.GetComponent<ObjectController>().offset);
            }
        }

        Move();

        if (Input.GetKeyDown(KeyCode.E))
        {
            cam.GetComponent<CamController>().currentCamera++;
            transform.position += offsetObject.GetComponent<ObjectController>().offset;
        }

        DeathCheck();
    }

    void Move()
    {
        camValue = cam.GetComponent<CamController>().currentCamera;
        if (camValue == 0)
        {
            MainCam();

        }

        else if (camValue == 1 || camValue == 2)
        {
            SideCam();
        }

        else if (camValue == 3)
        {
            TopCam();
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

    void DeathCheck()
    {
        if (lives == 0)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
