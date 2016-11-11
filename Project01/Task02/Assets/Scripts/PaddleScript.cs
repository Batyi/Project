using UnityEngine;
using System.Collections;
public class PaddleScript : MonoBehaviour {
	float paddleSpeed = 20f;
	public GameObject ballPrefab;
	GameObject attachedBall = null;
    public static int lives = 3;
    public AudioClip WallSound;
    GUIText guiLives;
	public static int score = 0, f = 0;
    private AudioSource audioSource;

    void Start () {
        if(f == 0)
        {
            Application.LoadLevel("2");
        }
        DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(GameObject.Find("guiLives"));
		guiLives = GameObject.Find("guiLives").GetComponent<GUIText>();
		guiLives.text = "Lives: " + lives;
		SpawnBall();
        audioSource = GetComponent<AudioSource>();
    }
	public void AddPoint(int v) {
		score += v;
        if(score >= 18)
            Application.LoadLevel("2");
    }
	public void LoseLife() {
		lives--;
		guiLives.text = "Lives: " + lives;
		if(lives > 0)
			SpawnBall();
		else if(lives <= 0) {
			Destroy(gameObject);
			Application.LoadLevel("2");
		}
	}
	public void SpawnBall() {
		attachedBall = (GameObject)Instantiate(ballPrefab, transform.position + new Vector3(0, .75f, 0), Quaternion.identity);
	}
	void OnGUI() {
		GUI.Label(new Rect(0, 10, 300, 100), "Score: " + score);
	}	
	void Update () {
		transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
		if (transform.position.x > 7.4f) {
			transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
		}
        if (transform.position.x < -7.4f) {
            transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);
        }
		if(attachedBall) {
			Rigidbody ballRigidbody = attachedBall.GetComponent<Rigidbody>();
			ballRigidbody.position = transform.position + new Vector3(0, .75f, 0);
			if(Input.GetButtonDown("LaunchBall")) {
				ballRigidbody.isKinematic = false;
				ballRigidbody.AddForce(300f * Input.GetAxis( "Horizontal" ), 400f, 0);
				attachedBall = null;
			}
		}
	}
	void OnCollisionEnter(Collision col) {
        audioSource.PlayOneShot(WallSound);
        audioSource.Play();
        foreach (ContactPoint contact in col.contacts) {
			if(contact.thisCollider == GetComponent<Collider>()) {
				float english = contact.point.x - transform.position.x;
				contact.otherCollider.GetComponent<Rigidbody>().AddForce(300f * english, 0, 0);
			}
		}
	}
}
