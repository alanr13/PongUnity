using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] Ball ball;
    public TextMeshProUGUI player1Score;
    public TextMeshProUGUI player2Score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void AddScore(TextMeshProUGUI playerScore)
    {
        playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
        ball.ResetBall();
    }
}
