using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lives = 3;
    public int score = 0;
    public int highScore = 0;
    public GameObject player;

    public string gameOverMessage = "You won!";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int addition)
    {
        score += addition;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void KillPlayer()
    {
        lives--;
        if (lives <= 0)
        {
            gameOverMessage = "You lost! Score: " + score;
            SceneManager.LoadScene("GameOver");
        }
    }

    public void AdvanceScene()
    {
        string currScene = SceneManager.GetActiveScene().name;
        if (currScene == "Menu") 
            SceneManager.LoadScene("Floor1");
        else if (currScene == "Floor1") 
            SceneManager.LoadScene("Floor2");
        else if (currScene == "Floor2") {
            gameOverMessage = "You won! Score: " + score;
            SceneManager.LoadScene("GameOver");
            lives = 3;
            score = 0;
        }
        else
        {
            SceneManager.LoadScene("Menu");
            lives = 3;
            score = 0;
        }   
    }
}
