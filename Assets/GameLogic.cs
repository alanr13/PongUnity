using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] TextMeshProUGUI player1Score;
    [SerializeField] TextMeshProUGUI player2Score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    [ContextMenu("AddScore")]
    public void AddScore()
    {
        if(ball.rb.position.x < -66.0f)
        {
            player2Score.text = (int.Parse(player2Score.text) + 1).ToString();
            ball.ResetBall();
        }
        else if(ball.rb.position.x > 66.0f)
        {
            player1Score.text = (int.Parse(player1Score.text) + 1).ToString();
            ball.ResetBall();
        }
    }
}
