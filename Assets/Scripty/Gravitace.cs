using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitace : MonoBehaviour
{
    void Start()
    {
        Physics.gravity *= 2f;
    }
}
