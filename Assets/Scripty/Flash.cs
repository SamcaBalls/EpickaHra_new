using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
    public GameObject fles;
    public GameObject poziceFlashe;
    public GameObject poziceFlash;
    private Vector3 poziceWau;
    private Vector3 poziceHau;
    private Quaternion randomRotace;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeLimit;
        aud = GetComponent<AudioSource>();
        gamblerScript = gambler.GetComponent<Gambler>();
        gamblerScript.FlashesCountChanged += OnFlashesCountChanged;
        flashesCount = gamblerScript.FlashesCount;
        poziceWau = poziceFlash.transform.position;
        poziceHau = poziceFlashe.transform.position;
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
            MakeRandomRotation();
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
    Quaternion MakeRandomRotation()
    {
        int RotaceX = UnityEngine.Random.Range(-180, 180);
        int RotaceY = UnityEngine.Random.Range(-180, 180);
        int RotaceZ = UnityEngine.Random.Range(-180, 180);
        Quaternion rotace = new Quaternion(RotaceX, RotaceY, RotaceZ, 0);
        randomRotace = rotace;
        return randomRotace;
    }
    IEnumerator FlashBum()
    {
        fles.transform.position = poziceWau;
        fles.transform.rotation = randomRotace;
        Vector3 direction = (poziceWau + new Vector3(6, 2, -poziceWau.z)).normalized;
        fles.GetComponent<Rigidbody>().velocity = direction * 7;
        canFlash = false;
        Debug.Log("flashing...");
        yield return new WaitForSeconds(1);
        if (Mathf.Approximately(gambler.transform.rotation.eulerAngles.y, 90f))
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAA pomoc fleš");
        }
        fles.transform.position = poziceHau;
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
        Gambler.Instance.UpdateFlashesCount(flashesCount);
    }
}
