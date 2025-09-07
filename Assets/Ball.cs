using UnityEngine;

public class Ball : MonoBehaviour
{
    GameLogic logic;
    int rand;
    private int moveSpeedInstances = 0;
    Vector2 direction;
    public float moveSpeed;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChooseDirection();

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
        ChooseDirection();
    }

    void ChooseDirection()
    {
        rand = Random.Range(1, 3);
        if (rand == 1)
        {
            direction = Vector3.right;
        }
        else if (rand == 2)
        {
            direction = Vector3.left;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "PaddleParts":
                if (moveSpeedInstances < 5)
                {
                    moveSpeedInstances++;
                    moveSpeed += 20.0f;
                }
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
