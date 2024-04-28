using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gambler : MonoBehaviour
{
    public event Action<int> FlashesCountChanged;
    private bool canGamble = true;
    public GameObject gamblerO;
    private Animator animator;
    public GameObject automat;
    public GameObject koule;
    private int flashesCount = 3;
    private int pocetGembleni;
    private int generovaneCislo = 10;
    private int pocetzagembleni;
    private static Gambler instance;
    private float time = 0;
    public GameObject door;
    private bool chillyGalewow = false;
    public GameObject chillyGale;
    private bool chillyCame = false;
    public static Gambler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Gambler>();
            }
            return instance;
        }
    }
    public int FlashesCount
    {
        get { return flashesCount; }
    }
    void Start()
    {
        animator = automat.GetComponent<Animator>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && canGamble == true && gamblerO.transform.rotation.y == 0) 
        {
            Gamble();
            animator.SetTrigger("Gamble");
            StartCoroutine(GambleCooldown());
            pocetGembleni++;
            pocetzagembleni++;
            time = 0;
        }
        if(pocetGembleni >= 5)
        {
            generovaneCislo++;
            Debug.Log("Šance zvíšena");
            pocetGembleni = 0;
        }
        if (time >= 5)
        {
            chillyGalewow = true;
        }
        if (chillyGalewow && (this.transform.rotation == Quaternion.Euler(0, 0, 0) || this.transform.rotation == Quaternion.Euler(0, -90, 0)))
        {
            ChillyGaleIsCumin();
        }
        baterkaBububu script = koule.GetComponent<baterkaBububu>();
        pocetzagembleni = script.pocetZagembleni;
    }

    IEnumerator GambleCooldown()
    {
        canGamble = false;
        yield return new WaitForSeconds(3);
        canGamble = true;
    }
    private void Gamble()
    {

        int ovocePicker1 = UnityEngine.Random.Range(0, generovaneCislo);
        int ovocePicker2 = UnityEngine.Random.Range(0, generovaneCislo);
        int ovocePicker3 = UnityEngine.Random.Range(0, generovaneCislo);

        int[] ovocePickers = { ovocePicker1, ovocePicker2, ovocePicker3 };
        for(int i = 0; i < 3; i++)
        {
            switch (ovocePickers[i])
            {
                case 0: Debug.Log("Švestka"); break;
                case 1: Debug.Log("Švestka"); break;
                case 2: Debug.Log("Citrón"); break;
                case 3: Debug.Log("Citrón"); break;
                case 4: Debug.Log("Tøešeò"); break;
                case 5: Debug.Log("Tøešeò"); break;
                case 6: Debug.Log("Hrozen"); break;
                case 7: Debug.Log("Hrozen"); break;
                case 8: Debug.Log("Meloun"); break;
                case 9: Debug.Log("Meloun"); break;
                default: Debug.Log("Sedmièka"); break;
            }
        }
        Debug.Log("-------------------------");
       if(ovocePicker1 >= 10 && ovocePicker2 >= 10 && ovocePicker3 >= 10)
        {
            Debug.Log("Vyhral jsi");
        }
        if (ovocePickers[0] / 2 == ovocePickers[1] / 2 && ovocePickers[1] / 2 == ovocePickers[2] / 2 && ovocePickers[0] < 10)
        {
            flashesCount++;
            OnFlashesCountChanged(flashesCount);
            Debug.Log("Máš " + flashesCount + " flashù.");
        }
    }
    private void OnFlashesCountChanged(int newCount)
    {
        FlashesCountChanged?.Invoke(newCount);
    }
    public void UpdateFlashesCount(int newCount)
    {
        flashesCount = newCount;
    }
    private void ChillyGaleIsCumin()
    {
        door.transform.position = new Vector3(11.999f, 2.24f, -7.962f);
        door.transform.rotation = Quaternion.Euler(0, 42.508f, 0);
        chillyGale.SetActive(true);
        chillyGale.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z - 2);
        chillyCame = true;

    }
}
