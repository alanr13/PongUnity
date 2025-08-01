using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }

        else if(Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
        }

        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector2((this.transform.position.x + direction.x), (this.transform.position.y + direction.y));
    }
}
