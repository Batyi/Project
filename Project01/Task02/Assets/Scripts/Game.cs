using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Text title;

    void Start()
    {
        if(PaddleScript.score == 0 && PaddleScript.lives == 3)
        {
            PaddleScript.f = 1;
            title.text = "Let's Play";
        }
        else if(PaddleScript.score >= 18 && PaddleScript.lives >= 1)
        {
            PaddleScript.score = 0;
            title.text = "You WON!";
            PaddleScript.f =  0;
            PaddleScript.lives = 3;
        }
        else
        {
            PaddleScript.lives = 3;
            PaddleScript.score = 0;
            title.text = "You Lost!";
            PaddleScript.f = 0;
        }
        StartCoroutine(BlinkTimer());
    }
    void Update()
    {
        if(Input.GetKeyDown("space")) SceneManager.LoadScene("1");
    }
    IEnumerator BlinkTimer()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("1");
    }
}
