using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    BoxCollider2D up, down, left, right; // четыре стены
    Vector2 zero, size;
    [SerializeField]
    float offset = 5f;
    [SerializeField]
    Transform player1;
    [SerializeField]
    Transform player2;
    [SerializeField]
    Transform ball;
    [SerializeField]
    GameController controller;

    void Start()
    {
        CreateWalls();
        CalculateWorldCoords();
        ChangeColliders();
        PlacePlayers();
        BindGates();
    }
    void CreateWalls()
    {
        up = CreateWall("up");
        down = CreateWall("down");
        left = CreateWall("left");
        right = CreateWall("right");
    }
    void CalculateWorldCoords()
    {
        zero = Camera.main.ScreenToWorldPoint(Vector3.zero);
        size = new Vector2
        (
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f)).x - zero.x,
            Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height)).y - zero.y
        );
    }
    void ChangeColliders()
    {
        float width = 1f;
        Vector2 verticalSize = new Vector2(width, size.y);
        left.size = right.size = verticalSize;

        left.transform.position = zero + new Vector2(-width / 2f, size.y / 2f);
        right.transform.position = zero + new Vector2(size.x + width / 2f, size.y / 2f);

        Vector2 horizontalSize = new Vector2(size.x, width);
        up.size = down.size = horizontalSize;

        up.transform.position = zero + new Vector2(size.x / 2f, size.y + width / 2f);
        down.transform.position = zero + new Vector2(size.x / 2f, -width / 2f);
    }
    void PlacePlayers()
    {
        float width = size.x * (offset / 100f);// процент ширины экрана
        player1.position = zero + new Vector2(width, size.y / 2f);
        player2.position = zero + new Vector2(size.x - width, size.y / 2f);
    }
    void BindGates()
    {
        Gate lGate = left.gameObject.AddComponent<Gate>();
        lGate.Direction = Direction.LEFT;

        Gate rGate = right.gameObject.AddComponent<Gate>();
        rGate.Direction = Direction.RIGHT;

        lGate.GameController = rGate.GameController = controller;
    }
    public void PlaceBall()
    {
        ball.position = zero + new Vector2(size.x / 2f, size.y / 2f);
    }
    BoxCollider2D CreateWall(string name)
    {
        GameObject go = new GameObject(name + "Wall"); // пустой объект с определенным именем
        BoxCollider2D collider = go.AddComponent<BoxCollider2D>(); // добавляем колайдер к этому объекту
        return collider; // возвращаем ссылку на колайдер
    }
}