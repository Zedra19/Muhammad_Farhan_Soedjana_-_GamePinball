using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private GameObject lampu;

    void Start()
    {
        lampu = gameObject.transform.GetChild(0).gameObject;
        var material = lampu.GetComponent<Renderer>().material;
        material.color = Color.black;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var material = lampu.GetComponent<Renderer>().material;
            if (material.color == Color.black)
            {
                material.color = Color.yellow;
            }
            else
            {
                material.color = Color.black;
            }
        }
    }
}
