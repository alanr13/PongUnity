using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    public Transform paddle;
    private Vector2 direction;
    [SerializeField] List<Transform> paddleSegments = new List<Transform>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Player1")
        {
            if (Input.GetKey(KeyCode.W))
            {
                direction = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.S))
            { direction = Vector2.down; }
            else
            { direction = Vector2.zero; }
        }
        else if (this.gameObject.tag == "Player2")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            { direction = Vector2.up; }
            else if (Input.GetKey(KeyCode.DownArrow))
            { direction = Vector2.down; }
            else { direction = Vector2.zero; }
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = direction * moveSpeed;

        // Ograniczenie ruchu paletki w osi Y
        float clampedY = Mathf.Clamp(rb.position.y, -24f, 24f); // podaj w³asne wartoœci
        rb.position = new Vector2(rb.position.x, clampedY);
    }
}