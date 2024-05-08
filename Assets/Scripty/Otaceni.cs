using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class SmoothRotation : MonoBehaviour
{
    private float rotationAmount = 90f;
    private float rotationDolu = 45f;
    private float rotationSpeed = 4f;
    public Gambler gamblerGay;

    private bool isRotating = false;
    private Quaternion targetRotation; 

    void Update()
    {
        if (!isRotating)
        {
            if (Input.GetButtonDown("Doprava") && Mathf.Approximately(transform.rotation.eulerAngles.x, 0))
            {
                targetRotation = transform.rotation * Quaternion.Euler(0, rotationAmount, 0);

                StartCoroutine(RotateObject());
            }
            if (Input.GetButtonDown("Doleva") && Mathf.Approximately(transform.rotation.eulerAngles.x, 0))
            {
                targetRotation = transform.rotation * Quaternion.Euler(0, -rotationAmount, 0);

                StartCoroutine(RotateObject());
            }
            if (Input.GetButtonDown("Dolu")&& Mathf.Approximately(gamblerGay.transform.rotation.eulerAngles.y, 0) && Mathf.Approximately(transform.rotation.eulerAngles.x, 0))
            {
                targetRotation = transform.rotation * Quaternion.Euler(rotationDolu, 0, 0);

                StartCoroutine(RotateObject());
            }
            if (Input.GetButtonDown("Nahoru") && Mathf.Approximately(transform.rotation.eulerAngles.x, 45))
            {
                targetRotation = transform.rotation * Quaternion.Euler(-rotationDolu, 0, 0);

                StartCoroutine(RotateObject());
            }
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
