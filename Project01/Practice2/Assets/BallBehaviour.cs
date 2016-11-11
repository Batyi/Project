using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    public float InputForceScale = 20f;
    public float InitialAngle = 45;
    public Vector3 initialImpulse;
    private Rigidbody rigidBody;

    void Start()
    {
        //GetComponent<Rigidbody>().AddForce(initialImpulse * 2, ForceMode.Impulse);
        rigidBody = GetComponent<Rigidbody>();
        Vector3 force = Quaternion.Euler(0, Random.Range(-90f, 90f), 0) * Vector3.forward;
        force = force * InputForceScale;
        rigidBody.AddForce(force);
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;
    }

    void Update()
    {

    }
}