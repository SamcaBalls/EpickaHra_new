using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private bool CanPress = true;
    public RectTransform textRectTransform; 
    public float moveSpeed = 50f; 
    public Image Black;
    public Animator anim;

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
            StartCoroutine(Fading());
            //text pujde nahoru
            textRectTransform.localPosition += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => Black.color.a == 1);
        isMoving = false;
        LoadNextScene();
        
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
