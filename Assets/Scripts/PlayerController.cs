using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rBody; // для управления
    [SerializeField]
    float speed; // скорость перемещения

    [SerializeField]
    KeyCode upButton; // кнопка вниз
    [SerializeField]
    KeyCode downButton; // кнопка вверх

    void Update()
    {
        Vector2 newVelocity = Vector2.zero; // нулевой вектор

        if (Input.GetKey(upButton))
            newVelocity.y = speed; // если кнопка вверх, делаем скорость по оси y
        else if (Input.GetKey(downButton))
            newVelocity.y = -speed; // если кнопка вниз, делаем скорость против оси y

        rBody.velocity = newVelocity;
    }
}