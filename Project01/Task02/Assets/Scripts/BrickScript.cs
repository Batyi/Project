using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
	static int numBricks = 0;
	public int pointValue = 1;
	public GameObject[] powerUpPrefabs;
    void Start () {
		numBricks++;
	}
	void OnCollisionEnter(Collision col ) {
        Die();
	}
	void Die() {
		Destroy(gameObject);
		PaddleScript paddleScript = GameObject.Find ("paddle").GetComponent<PaddleScript>();
		paddleScript.AddPoint(pointValue);
		numBricks--;
    }
}
