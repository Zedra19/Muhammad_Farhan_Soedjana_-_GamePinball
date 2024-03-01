using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject generalSFX;
    AudioSource clickSFX;
    // Start is called before the first frame update
    void Start()
    {
        generalSFX = GameObject.Find("GeneralSFX");
        clickSFX = generalSFX.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playButton()
    {
        clickSFX.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitButton()
    {
        clickSFX.Play();
        Application.Quit();
    }
}