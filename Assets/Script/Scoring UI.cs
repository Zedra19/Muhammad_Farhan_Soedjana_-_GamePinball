using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringUI : MonoBehaviour
{
    public Text scoreText;
    public int hasilScore;
    public Text highsScoreText;
    [SerializeField] int highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + hasilScore;
        highsScoreText.text = "Highscore: " + highscore;
        if(hasilScore > highscore)
        {
            highscore = hasilScore;
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
}
