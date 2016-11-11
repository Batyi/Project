using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallBehaviour : MonoBehaviour
{
    public float InputForceScale = 20f;
    public Vector3 initialImpulse;
    private Rigidbody rigidBody;
    public AudioClip WallSound;
    public AudioClip PaddleSound;
    public AudioClip LostSound;
    private AudioSource audioSource;

    void Start()
    {
        //GetComponent<Rigidbody>().AddForce(initialImpulse * 2, ForceMode.Impulse);
        rigidBody = GetComponent<Rigidbody>();
        Vector3 force = Quaternion.Euler(0, Random.Range(-90f, 90f), 0) * Vector3.forward;
        force = force * InputForceScale;
        rigidBody.AddForce(force);
        audioSource = GetComponent<AudioSource>();
        
    }
    IEnumerator BlinkTimer()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("1");
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Walls"))
        {
            audioSource.PlayOneShot(WallSound);
        }
        else if (gameObject.CompareTag("Paddle"))
        {
            audioSource.PlayOneShot(PaddleSound);
        }
        else if(gameObject.CompareTag("Border"))
        {
            audioSource.PlayOneShot(LostSound);
        }
    }

    void Update()
    {
    }
}
