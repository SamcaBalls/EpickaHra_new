using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private bool CanPress = true;
    public RectTransform textRectTransform; // Reference to the RectTransform of the text
    public float moveSpeed = 50f; // Speed at which the text moves up
    public float moveDistance = 100f; // Distance to move the text

    private Vector3 initialPosition;
    private bool isMoving = false;

    void Start()
    {
        initialPosition = textRectTransform.localPosition;
    }

    void Update()
    {
        if (isMoving)
        {
            // Move the text upwards
            textRectTransform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;

            // Check if the text has moved the desired distance
            if (Vector3.Distance(textRectTransform.localPosition, initialPosition) >= moveDistance)
            {
                isMoving = false;
                LoadNextScene();
            }
        }
    }

    public void PlayGame()
    {
        if (CanPress)
        {
            CanPress = false;
            isMoving = true; // Start moving the text
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUITING GAME (v Unity to nejde quitnout)");
        Application.Quit();
    }
}
