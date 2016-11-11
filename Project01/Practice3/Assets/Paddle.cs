using UnityEngine;
using System.Collections;

public enum EPaddle
{
    Left,
    Right
}

public class Paddle : MonoBehaviour
{
    public float speed = 15f;
    public EPaddle player;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        float inputSpeed = 0f;
        if (player == EPaddle.Left)
        {
            inputSpeed = Input.GetAxisRaw("PlayerLeft");
        }
        else if (player == EPaddle.Right)
        {
            inputSpeed = Input.GetAxisRaw("PlayerRight");
        }
        //  transfrom.position += new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);
        transform.Translate(0f, 0f, inputSpeed * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Ball"))
        {
            GameObject ball = gameObject;
            float shift = ball.transform.position.x - transform.position.x;
            Vector3 force = new Vector3(100 + shift, 0.0f, 0.0f) * 2f;
            ball.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}

