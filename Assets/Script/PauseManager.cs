using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject generalSFX;
    AudioSource pauseSFX;
    // Start is called before the first frame update
    void Start()
    {
        generalSFX = GameObject.Find("GeneralSFX");
        pauseSFX = generalSFX.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pauseButton()
    {
        if(pausePanel.activeSelf)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            pauseSFX.Play();
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            pauseSFX.Play();
        }
    }

    public void resumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        pauseSFX.Play();
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseSFX.Play();
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        pauseSFX.Play();
    }
}
