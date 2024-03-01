using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    ScoringUI scoringUI;
    [SerializeField] bool score20Bool;
    [SerializeField] bool score20CylinderBool;
    [SerializeField] bool score30Bool;
    [SerializeField] bool score30CylinderBool;
    [SerializeField] bool score80Bool;
    [SerializeField] float bonusTimer;
    int score20 = 20;
    int score30 = 30;
    int score80 = 80;
    public GameObject scoringSFX;
    AudioSource SFX;

    // Start is called before the first frame update
    void Start()
    {
        scoringUI = FindAnyObjectByType<ScoringUI>();
        scoringSFX = GameObject.Find("ScoringSFX");
        SFX = scoringSFX.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(score20Bool)
            {
                scoringUI.hasilScore += score20;
                SFX.Play();
            }else if(score30Bool)
            {
                scoringUI.hasilScore += score30;
                SFX.Play();
            }
            else if (score80Bool)
            {
                scoringUI.hasilScore += score80;
                SFX.Play();
                gameObject.SetActive(false);
                timer();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (score20CylinderBool)
            {
                scoringUI.hasilScore += score20;
                SFX.Play();
            }
            else if (score30CylinderBool)
            {
                scoringUI.hasilScore += score30;
                SFX.Play();
            }
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(bonusTimer);
        gameObject.SetActive(true);
    }
}
