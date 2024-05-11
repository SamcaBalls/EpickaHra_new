using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Flash : MonoBehaviour
{
    private bool canFlash = true;
    private int flashesCount;
    private Gambler gamblerScript;
    public baterkaBububu bubuScript;
    private float timeLimit = 5f;
    private float currentTime = 0f;
    public GameObject gambler;
    private AudioSource aud;
    public GameObject obluda;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeLimit;
        aud = GetComponent<AudioSource>();
        gamblerScript = gambler.GetComponent<Gambler>();
        gamblerScript.FlashesCountChanged += OnFlashesCountChanged;
        flashesCount = gamblerScript.FlashesCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (bubuScript.flashingPosition == true)
        {
            flashEvent();
        }
        if (Mathf.Approximately(gambler.transform.rotation.eulerAngles.y, 90f) && Input.GetButtonDown("Fire1") && canFlash == true && flashesCount > 0)
        {
            StartCoroutine(FlashBum());
        }
    }

    private void flashEvent()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            JumpScare();
        }
        else
        {
            FlashBum();
        }
    }
    IEnumerator FlashBum()
    {
        canFlash = false;
        Debug.Log("flashing...");
        yield return new WaitForSeconds(1);
        aud.Play();
        bubuScript.playAudio = true;
        obluda.transform.position = new Vector3(0, 0, 30);
        bubuScript.aktualniPozice = 0;
        currentTime = timeLimit;
        flashesCount--;
        OnFlashesCountChanged(flashesCount);
        bubuScript.flashingPosition = false;
        yield return new WaitForSeconds(3);
        canFlash = true;
    }
    private void JumpScare()
    {
        Debug.Log("Prohrál jsi");
    }
    private void OnFlashesCountChanged(int newCount)
    {
        flashesCount = newCount;
        Debug.Log("Poèet zábleskù zmìnìn na: " + flashesCount);
        // Pøedáváme aktuální hodnotu flashesCount tøídì Gambler
        Gambler.Instance.UpdateFlashesCount(flashesCount);
    }
}
