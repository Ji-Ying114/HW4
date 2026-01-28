using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    private int score = 0;

    private void OnEnable()
    {
        Bird bird = Locator.instance.bird;
        bird.OnScoreEarned += HandleScoreEarned;
    }
    
    private void HandleScoreEarned()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
