using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rBody;

    [SerializeField]
    float speedX = 10f;
    [SerializeField]
    float topYSpeed = 10f;
    public void Push()
    {
        Vector2 newVel = Vector2.zero;
        newVel.y = Random.Range(-topYSpeed, topYSpeed);

        float randomNum = Random.Range(0f, 1f);
        if (randomNum >= 0.5f)
            newVel.x = speedX;
        else
            newVel.x = -speedX;
        rBody.velocity = newVel;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            // получить ссылку на компонент Rigidbody2D
            Rigidbody2D playerRB = col.gameObject.GetComponent<Rigidbody2D>();
            Vector2 newVel = rBody.velocity;
            newVel.y = rBody.velocity.y / 2f + playerRB.velocity.y / 3f;
            rBody.velocity = newVel;
        }
    }
    public void Stop()
    {
        rBody.velocity = Vector2.zero;
    }
}