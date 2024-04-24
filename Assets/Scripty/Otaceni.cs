using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    private float rotationAmount = 90f; 
    private float rotationSpeed = 4f; 

    private bool isRotating = false;
    private Quaternion targetRotation; 

    void Update()
    {
        if (Input.GetButtonDown("Doprava") && !isRotating)
        {
            targetRotation = transform.rotation * Quaternion.Euler(0, rotationAmount, 0);

            StartCoroutine(RotateObject());
        }
        if (Input.GetButtonDown("Doleva") && !isRotating)
        {
            targetRotation = transform.rotation * Quaternion.Euler(0, -rotationAmount, 0);

            StartCoroutine(RotateObject());
        }
    }

    IEnumerator RotateObject()
    {
        isRotating = true;

        Quaternion startRotation = transform.rotation;

        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            Quaternion newRotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);

            transform.rotation = newRotation;

            elapsedTime += Time.deltaTime * rotationSpeed;

            yield return null;
        }

        transform.rotation = targetRotation;

        isRotating = false;
    }
}
