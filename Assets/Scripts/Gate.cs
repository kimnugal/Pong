using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameController GameController { get; set; }
    public Direction Direction { get; set; }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ball") // если это шар
        {
            GameController.GoalDetected(Direction); // то оповестить game controller
        }
    }
}