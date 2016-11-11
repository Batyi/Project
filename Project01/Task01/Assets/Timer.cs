using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
	private float time = 30;
	public Text timerText;

	void Start () {
		timerText = GetComponent<Text> ();
	}
	void Update () {
		time -= Time.deltaTime;
		timerText.text = ((int)time).ToString();
		if (time < 0) {
			SceneManager.LoadScene ("2");
		}
	}
}
