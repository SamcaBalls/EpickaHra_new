using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovementScript : MonoBehaviour
{
    public float sensitivity = 0.15f;
    public float maxX = 10f;
    public float maxY = 10f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float cameraRotationY = transform.eulerAngles.y;

        if ((cameraRotationY >= 315f || cameraRotationY < 45f) || (cameraRotationY >= 135f && cameraRotationY < 225f))
        {
            TurningOnX();
        }
        else if ((cameraRotationY >= 45f && cameraRotationY < 135f) || (cameraRotationY >= 225f && cameraRotationY < 315f))
        {
            TurningOnZ();
        }
    }
    void TurningOnX()
    {
        Vector3 mousePosition = Input.mousePosition;

        float xMovement = (mousePosition.x / Screen.width) * 2 - 1;
        float yMovement = (mousePosition.y / Screen.height) * 2 - 1;

        Vector3 newPosition = initialPosition + new Vector3(xMovement, yMovement, 0) * sensitivity;

        newPosition.x = Mathf.Clamp(newPosition.x, initialPosition.x - maxX, initialPosition.x + maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, initialPosition.y - maxY, initialPosition.y + maxY);

        transform.position = newPosition;
    }
    void TurningOnZ()
    {
        float zMovement = Input.GetAxis("Mouse X");
        float yMovement = Input.GetAxis("Mouse Y");

        Vector3 worldMovement = Camera.main.transform.forward * zMovement + Camera.main.transform.up * yMovement;

        Vector3 newPosition = initialPosition + worldMovement * sensitivity;

        newPosition.z = Mathf.Clamp(newPosition.z, initialPosition.z - maxX, initialPosition.z + maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, initialPosition.y - maxY, initialPosition.y + maxY);

        transform.position = newPosition;
    }
}


