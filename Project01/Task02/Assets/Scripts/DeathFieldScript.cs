using UnityEngine;
using System.Collections;

public class DeathFieldScript : MonoBehaviour {
	void OnTriggerEnter( Collider other ) {	
		BallScript ballScript = other.GetComponent<BallScript>();
		if(ballScript) {
			ballScript.Die();
		}
	}
}
