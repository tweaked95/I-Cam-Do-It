using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuImage : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, transform.position);

        if (plane.Raycast(ray, out float dist))
        {
            Vector3 hitpoint = ray.GetPoint(dist);
            //transform.LookAt(hitpoint);

            Vector3 direction = hitpoint - transform.position;

            float signedAngle = Vector3.SignedAngle(Vector3.left, direction, Vector3.forward);
            Debug.Log(signedAngle);
            signedAngle = Mathf.Clamp(signedAngle, -30, 30);
            transform.rotation = Quaternion.Euler(signedAngle, -90, 0);
        }

        //Mathf.Clamp(transform.eulerAngles.x, -20, 30);
    }
}
