using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public GameObject losePanel;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            losePanel.SetActive(true);
            SFX.Play();
        }
    }
}
