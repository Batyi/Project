using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Text title;

    void Start()
    {
        if (Border.firstPlayer > Border.secondPlayer) title.text = "WINNER - PLAYER #1!";
        else if (Border.firstPlayer < Border.secondPlayer) title.text = "WINNER - PLAYER #2!";
        else if (Border.firstPlayer == 0 && Border.secondPlayer == 0) title.text = "Let's Play!";
        else title.text = "Draw";
        Border.firstPlayer = 0;
        Border.secondPlayer = 0;
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
