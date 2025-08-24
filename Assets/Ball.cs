using UnityEngine;

public class Ball : MonoBehaviour
{
    int rand;
    Vector2 direction;
    public float moveSpeed;
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rand = Random.Range(1, 3);

        if (rand == 1)
        {
            direction = Vector3.right;
        }
        else
        {
            direction = Vector3.left;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * moveSpeed);
    }
}
