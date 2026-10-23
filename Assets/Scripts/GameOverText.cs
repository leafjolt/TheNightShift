using TMPro;
using UnityEngine;

public class GameOverText : MonoBehaviour
{
    public TMP_Text titleText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        titleText.text = GameManager.instance.gameOverMessage;
    }
}
