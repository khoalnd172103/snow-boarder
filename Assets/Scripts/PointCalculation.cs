using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PointCalculation : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;

    [SerializeField]
    private Transform finishLine;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private float score;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("highestSceneNumber", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        score = (transform.position.x - startPoint.transform.position.x) * 100 / (finishLine.transform.position.x - startPoint.transform.position.x);

        scoreText.text = "Distance travel: " + score.ToString("F1") + " %";

    }

    public float ReturnCurrentScore()
    {
        return score;
    }
}
