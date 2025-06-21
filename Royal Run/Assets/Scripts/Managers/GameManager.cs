using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 60f;

    float timeLeft;
    bool gameOver = false;


    public bool GameOver
    {
        get { return gameOver; }
    }

    void Start()
    {
        timeLeft = startTime;
    }

    void Update()
    {

        DecreaseTime();
    }


    public void IncreaseTime(float amount)
    {
        timeLeft += amount;
    }


    void DecreaseTime()
    {
        if (gameOver) return;
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1"); // F1 implies one decimal place will be shown  

        if (timeLeft <= 0)
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = .1f;
    }
}
