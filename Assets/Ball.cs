using UnityEngine;

public class Ball : MonoBehaviour
{
    GameLogic logic;
    int rand;
    private int moveSpeedInstances = 0;
    Vector2 direction;
    private float moveSpeed = 25f;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LaunchBall();

        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * moveSpeed;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameLogic>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {

    }

    public void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        rb.transform.position = Vector2.zero;

        moveSpeedInstances = 0;
        moveSpeed = 25f;
        Invoke("LaunchBall", 1f);
    }

    void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-0.75f, 0.75f);

        direction = new Vector2(x, y).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.layer)
        {
            case 8:
                if (moveSpeedInstances < 5)
                {
                    moveSpeedInstances++;
                    moveSpeed += 20.0f;
                }
                Debug.Log("Hit Paddle");
                direction = Vector2.Reflect(direction, collision.contacts[0].normal);
                rb.linearVelocity = direction * moveSpeed;
                break;
            case 7:
                Debug.Log("Hit Paddle");
                direction = Vector2.Reflect(direction, collision.contacts[0].normal);
                rb.linearVelocity = direction * moveSpeed;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Detector_Left":
                logic.AddScore(logic.player2Score);
                break;
            case "Detector_Right":
                logic.AddScore(logic.player1Score);
                break;
        }
    }
}
