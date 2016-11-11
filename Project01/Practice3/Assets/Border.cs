using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Border : MonoBehaviour
{
    public EPaddle player;
    private AudioSource audioSource;
    public Text f1;
    public Text s1;
    public static int firstPlayer;
    public static int secondPlayer;

    void OnCollisionEnter(Collision col)
    {
        BallBehaviour ball = col.gameObject.GetComponent<BallBehaviour>();
        if(ball != null)
        {
            ball.transform.position = new Vector3(0f, 1f, 0f);
            /*
            float shift = ball.transform.position.x - transform.position.x;
            Vector3 force = new Vector3(180f, 0.0f, 0.0f) * 2f;
            ball.GetComponent<Rigidbody>().AddForce(force);
            */
            
            if (player == EPaddle.Right)
            {
                ++firstPlayer;
                f1.text = firstPlayer.ToString();
                audioSource.Play();
            }
            else if (player == EPaddle.Left)
            {
                ++secondPlayer;
                s1.text = secondPlayer.ToString();
                audioSource.Play();
            }
        }
    }
}
