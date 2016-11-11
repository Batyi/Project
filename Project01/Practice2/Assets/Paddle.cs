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
    public float InputForceScale = 20f;
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
        
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 force = new Vector3(horizontalAxis, 0, 0);
        force = force * InputForceScale;
        rigidBody.AddForce(force);
        
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Ball"))
        {
            GameObject ball = gameObject;
            float shift = ball.transform.position.x - transform.position.x;
            Vector3 force = new Vector3(shift, 0.0f, 0.0f) * 4f;
            ball.GetComponent<Rigidbody>().AddForce(force);
        }
    }
}

