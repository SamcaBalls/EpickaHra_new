using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gambler : MonoBehaviour
{
    private bool canGamble = true;
    public GameObject gamblerO;
    private Animator animator;
    public GameObject automat;
    private int flashesCount = 3;
    private int pocetGembleni;
    private int generovaneCislo = 10;
    private AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        animator = automat.GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MusicAmb());
        if (Input.GetButtonDown("Fire1") && canGamble == true && gamblerO.transform.rotation.y == 0) 
        {
            Gamble();
            animator.SetTrigger("Gamble");
            StartCoroutine(GambleCooldown());
            pocetGembleni++;
        }
        if(pocetGembleni >= 5)
        {
            generovaneCislo++;
            Debug.Log("Šance zvíšena");
            pocetGembleni = 0;
        }
    }
        IEnumerator MusicAmb()
        {
            yield return new WaitForSeconds(47);
            audi.Play();
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
                case >=10: Debug.Log("Sedmièka"); break;
            }
        }
        Debug.Log("-------------------------");
       if(ovocePicker1 >= 10 && ovocePicker2 >= 10 && ovocePicker3 >= 10)
        {
            Debug.Log("Vyhral jsi");
        }
        if(ovocePicker1 / 2 == ovocePicker2 / 2 && ovocePicker1 / 2 == ovocePicker3 / 2 && ovocePicker1 != 10)
        {
            flashesCount++;
            Debug.Log("Máš " + flashesCount + " flashù.");
        }
    }
}
