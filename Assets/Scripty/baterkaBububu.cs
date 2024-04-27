using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baterkaBububu : MonoBehaviour
{
    public GameObject obluda;
    public GameObject gambler;
    private bool canGamble = true;
    public int pocetZagembleni = 0;
    private int aktualniPozice = 0;
    private bool flashingPosition = false;
    private float timeLimit = 5f;
    private float currentTime = 0f;
    private AudioSource aud;
    public bool playAudio = false;
    private bool canFlash = true;
    private int flashesCount;
    private Gambler gamblerScript;

    private void Start()
    {
        currentTime = timeLimit;
        aud = GetComponent<AudioSource>();
        gamblerScript = gambler.GetComponent<Gambler>();
        gamblerScript.FlashesCountChanged += OnFlashesCountChanged;
        flashesCount = gamblerScript.FlashesCount;
    }
    void Update()
    {
        
        if(Input.GetButtonDown("Fire1") && canGamble == true && gambler.transform.rotation.y == 0)
        {          
            StartCoroutine(GambleCooldown());
            pocetZagembleni++;
        }
        if(pocetZagembleni == 3)
        {
            MoveChance();
        }
        if (flashingPosition == true)
        {
            flashEvent();   
        }
        if(Mathf.Approximately(gambler.transform.rotation.eulerAngles.y, 90f) && Input.GetButtonDown("Fire1") && canFlash == true)
        {
            StartCoroutine(Flash());
        }
    }
    IEnumerator GambleCooldown()
    {
        canGamble = false;
        yield return new WaitForSeconds(0);
        canGamble = true;
    }

    private void MoveChance()
    {
        int move = Random.Range(0, 2);
        Debug.Log(move);
        if(move == 1)
        {
            switch(aktualniPozice)
            {
                case 0: prvniPozice(move); break;
                case 1: druhaPozice(move); break;
                case 2: tretiPozice(move); break;
                case 3: ctvrtaPozice(move); break;
                case 4: pataPozice(move); break;
                case 5: sestaPozice(move); break;
            }
        }
        pocetZagembleni = 0;
    }
    private void prvniPozice(int move)
    {
        if (move == 1 && aktualniPozice == 0)
        {
            obluda.transform.position = new Vector3(31.21f, 1.65f, -11.89f);
            obluda.transform.rotation = Quaternion.Euler(3.912f, -90f, -24.685f);
            aktualniPozice++;
        }
    }
    private void druhaPozice(int move)
    {
        if (move == 1 && aktualniPozice == 1)
        {
            obluda.transform.position = new Vector3(23f, 1.65f, -7.2f);
            obluda.transform.rotation = Quaternion.Euler(0, -90, 29f);
            aktualniPozice++;
        }
    }
    private void tretiPozice(int move)
    {
        if (move == 1 && aktualniPozice == 2)
        {
            obluda.transform.position = new Vector3(21.8f, 7f, -16.08f);
            obluda.transform.rotation = Quaternion.Euler(-0.323f, -90, -148.362f);
            aktualniPozice++;
        }
    }
    private void ctvrtaPozice(int move)
    {
        if (aktualniPozice == 3)
        {
            int nextLokace = UnityEngine.Random.Range(0, 2);
            if (move == 1 && aktualniPozice == 3 && nextLokace == 0)
            {
                obluda.transform.position = new Vector3(16.16127f, 0.9821391f, -17.34027f);
                obluda.transform.rotation = Quaternion.Euler(5.877f, -73.12f, -25.142f);
                aktualniPozice++;
            }
            else if(move == 1 && aktualniPozice == 3 && nextLokace == 1)
            {
                obluda.transform.position = new Vector3(11.59219f, 1.412593f, -9.544255f);
                obluda.transform.rotation = Quaternion.Euler(19.526f, -101.96f, -23.445f);
                aktualniPozice++;
            }
        }
        
    }
    private void pataPozice(int move)
    {
        int nextLokace = UnityEngine.Random.Range(0, 2);
        if (move == 1 && aktualniPozice == 4 && nextLokace == 0)
        {
            obluda.transform.position = new Vector3(6.946588f, 2.6f, -17f);
            obluda.transform.rotation = Quaternion.Euler(41.413f, -36.408f, -36.408f);
            aktualniPozice++;
        }
        else if (move == 1 && aktualniPozice == 4 && nextLokace == 1)
        {
            obluda.transform.position = new Vector3(3.82f, 0.75f, -12f);
            obluda.transform.rotation = Quaternion.Euler(28.488f, -82.353f, 6.313f);
            flashingPosition = true;
            aktualniPozice++;
        }
    }
    private void sestaPozice(int move)
    {

        if (move == 1 && aktualniPozice == 5)
        {
            obluda.transform.position = new Vector3(3.82f, 0.75f, -12f);
            obluda.transform.rotation = Quaternion.Euler(28.488f, -82.353f, 6.313f);
            flashingPosition = true;
            aktualniPozice++;
        }
    }
    
    private void flashEvent()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            JumpScare();
        } else
        {
            Flash();
        }
    }
    IEnumerator Flash()
    {
        canFlash = false;
        Debug.Log("flashing...");
        yield return new WaitForSeconds(1);
        aud.Play();
        playAudio = true;
        obluda.transform.position = new Vector3(0, 0, 30);
        aktualniPozice = 0;
        currentTime = timeLimit;
        flashesCount--;
        OnFlashesCountChanged(flashesCount);
        flashingPosition = false;
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

