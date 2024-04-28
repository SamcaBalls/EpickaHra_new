using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gambler : MonoBehaviour
{
    public event Action<int> FlashesCountChanged;
    private Animator animatorGembl1;
    private Animator animatorGembl2;
    private Animator animatorGembl3;
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
    public GameObject okenko1;
    public GameObject okenko2;
    public GameObject okenko3;
    private Animator[] animators;
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
        animatorGembl1 = okenko1.GetComponent<Animator>();
        animatorGembl2 = okenko2.GetComponent<Animator>();
        animatorGembl3 = okenko3.GetComponent<Animator>();
        animators = new Animator[3];
        animators[0] = animatorGembl1;
        animators[1] = animatorGembl2;
        animators[2] = animatorGembl3;
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
        if(pocetGembleni >= 15)
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
            ChillyGaleIsCumin(chillyCame);
        }
        baterkaBububu script = koule.GetComponent<baterkaBububu>();
        pocetzagembleni = script.pocetZagembleni;
    }

    IEnumerator GambleCooldown()
    {
        canGamble = false;
        yield return new WaitForSeconds(2.5f);
        canGamble = true;
    }
    private void Gamble()
    {

        int ovocePicker1 = UnityEngine.Random.Range(0, generovaneCislo);
        int ovocePicker2 = UnityEngine.Random.Range(0, generovaneCislo);
        int ovocePicker3 = UnityEngine.Random.Range(0, generovaneCislo);
        Debug.Log(ovocePicker1);
        Debug.Log(ovocePicker2);
        Debug.Log(ovocePicker3);
        int[] ovocePickers = { ovocePicker1, ovocePicker2, ovocePicker3 };
        for(int i = 0; i < 3; i++)
        {
            switch (ovocePickers[i])
            {
                case 0: animators[i].SetTrigger("Citron"); break;
                case 1: animators[i].SetTrigger("Citron"); break;
                case 2: animators[i].SetTrigger("Tresen"); break;
                case 3: animators[i].SetTrigger("Tresen"); break;
                case 4: animators[i].SetTrigger("Svestka"); break;
                case 5: animators[i].SetTrigger("Svestka"); break;
                case 6: animators[i].SetTrigger("Nota"); break;
                case 7: animators[i].SetTrigger("Nota"); break;
                case 8: animators[i].SetTrigger("Meloun"); break;
                case 9: animators[i].SetTrigger("Meloun"); break;
                default: animators[i].SetTrigger("Sedmicka"); break;
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
    private void ChillyGaleIsCumin(bool chillyCame)
    {
        door.transform.position = new Vector3(11.999f, 2.24f, -7.962f);
        door.transform.rotation = Quaternion.Euler(0, 42.508f, 0);
        chillyGale.SetActive(true);
        chillyGale.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z - 2);
        chillyCame = true;

    }
}
