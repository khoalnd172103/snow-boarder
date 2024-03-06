using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PointCalculation : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;

    [SerializeField]
    private Transform finishLine;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private float score;
    private float highScore;

    private bool isCompleteRotation;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        if (finishLine.position.x <= transform.position.x)
        {
            scoreText.text = "You win";
        }
        else
        {
            highScoreText.text = "High score: " + highScore.ToString("F1");

            score = (transform.position.x - startPoint.transform.position.x);
            if (score > 1.0)
            {
                scoreText.text = "Score: " + score.ToString("F1");
            }


            if (highScore < score)
            {
                highScore = score;
                PlayerPrefs.SetFloat("highScore", score);
            }
        }
    }

    public float ReturnCurrentScore()
    {
        return score;
    }
}
