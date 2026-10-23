using TMPro;
using UnityEngine;

public class TextHandler : MonoBehaviour
{
    public TMP_Text livesText;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + GameManager.instance.lives;
        scoreText.text = "Score: " + GameManager.instance.score;
        highScoreText.text = "High Score: " + GameManager.instance.highScore;
    }
}
