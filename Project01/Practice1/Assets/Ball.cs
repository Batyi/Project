using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{

    public Vector3 initialImpulse;

    // Use this for initialization
    void Start()
    {

        GetComponent<Rigidbody>().AddForce(initialImpulse * 2, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
