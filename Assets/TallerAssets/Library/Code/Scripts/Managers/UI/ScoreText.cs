using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    void Awake()
    {
        scoreText= GetComponent<TextMeshProUGUI>();
        if(scoreText==null)
            scoreText=GetComponentInChildren<TextMeshProUGUI>();


    }

    void OnEnable()
    {
        GameManager.OnScoreChanged += GameManager_OnScoreChanged;
         

    }

 

    void OnDisable()
    {
        GameManager.OnScoreChanged -= GameManager_OnScoreChanged;

    }
   
    void Start()
    {
        GameManager.Instance.AddScore(0);

    }
    private void GameManager_OnScoreChanged(int Param1)
    {
        if (scoreText == null)return;
        scoreText.text=Param1.ToString();

    }
}
