using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public GameObject generalSFX;
    AudioSource SFX;
    // Start is called before the first frame update
    void Start()
    {
        generalSFX = GameObject.Find("GeneralSFX");
        SFX = generalSFX.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        SFX.Play();
    }
}
