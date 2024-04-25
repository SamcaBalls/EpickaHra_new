using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HartBit : MonoBehaviour
{
    private baterkaBububu baterka;
    private AudioSource audio1;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = GetComponent<AudioSource>();
        baterka = FindObjectOfType<baterkaBububu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(baterka.playAudio == true)
        {
            StartCoroutine(playAudio());
        }
    }
    private IEnumerator playAudio()
    {
        baterka.playAudio = false;
        yield return new WaitForSeconds(1);
        Debug.Log("hraju hart bít");
        audio1.Play();
    }
}
