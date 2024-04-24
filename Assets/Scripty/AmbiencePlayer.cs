using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiencePlayer : MonoBehaviour
{
    private AudioSource audi;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
        StartCoroutine(MusicAmb());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MusicAmb()
    {
        yield return new WaitForSeconds(1);
        audi.Play();
    }
}
