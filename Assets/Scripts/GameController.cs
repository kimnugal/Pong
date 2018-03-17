using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    BallController ball;
    [SerializeField]
    SceneSetup setup;

    [SerializeField]
    Text scoreText;

    int player1Score = 0;
    int player2Score = 0;

    void Start()
    {
        scoreText.text = "0:0";
        setup.PlaceBall();
        ball.Push();
    }
    public void GoalDetected(Direction dir)
    {
        if (dir == Direction.LEFT)
            ++player2Score;
        else
            ++player1Score;

        setup.PlaceBall();
        ball.Stop(); // останавливаем шар
        scoreText.text = player1Score.ToString() + ":" + player2Score;
        Invoke("PushBall", 1f); // вызываем запуск шара через секунду
    }
    void PushBall()
    {
        ball.Push();
    }
}