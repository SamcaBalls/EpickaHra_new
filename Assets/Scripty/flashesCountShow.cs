using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class flashesCountShow : MonoBehaviour
{
    public event Action<int> FlashesCountChanged;
    private int flashesCount;
    private Gambler gamblerScript;
    public GameObject gambler;
    public GameObject c0;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    public GameObject c6;
    public GameObject c7;
    public GameObject c8;
    public GameObject c9;
    public GameObject c10;
    public GameObject c11;
    public GameObject c12;
    public GameObject c13;
    public GameObject c14;
    public GameObject c15;
    public GameObject c16;
    public GameObject c17;
    public GameObject c18;
    public GameObject c19;
    public GameObject c20;
    private int currentFlashesCount;
    void Start()
    {
        gamblerScript = gambler.GetComponent<Gambler>();
        gamblerScript.FlashesCountChanged += OnFlashesCountChanged;
    }

    void Update()
    {
        flashesCount = gamblerScript.FlashesCount;
        DisplayCislo();
    }

    void DisplayCislo()
    {
        currentFlashesCount = flashesCount;
        GameObject[] cArray = { c0, c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20 };
        
        if(currentFlashesCount == flashesCount)
        {
            cArray[flashesCount].SetActive(true);
        }
        else
        {
            cArray[flashesCount].SetActive(false);
        }
        
    }

    private void OnFlashesCountChanged(int newCount)
    {
        FlashesCountChanged?.Invoke(newCount);
    }
}
