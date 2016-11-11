using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public void Die() {
		Destroy(gameObject);
		GameObject paddleObject = GameObject.Find("paddle");
		PaddleScript paddleScript = paddleObject.GetComponent<PaddleScript>();
		paddleScript.LoseLife();
	}
}
