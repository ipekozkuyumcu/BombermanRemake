using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndController : MonoBehaviour
{
    public Text Winner;
    public Text Score;

    // Start is called before the first frame update
    void Start()
    {
        int P1_Score = ScoreKeeper.P1Score;
        int P2_Score = ScoreKeeper.P2Score;

        if(P1_Score > P2_Score)
        {
            Winner.color = Color.red;
            Winner.text = "Player 1 is the winner!";
        }
        else if(P1_Score < P2_Score)
        {
            Winner.color = Color.blue;
            Winner.text = "Player 2 is the winner!";
        }
        else if(P1_Score == P2_Score)
        {
            Winner.color = Color.yellow;
            Winner.text = "Nobody is the winner! Tie!";
        }

        Score.text = P1_Score.ToString() + " - " + P2_Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            /*SceneManager.LoadScene("Menu");
            ScoreKeeper.P1Score = 0;
            ScoreKeeper.P2Score = 0;*/

            Application.Quit();
        }
    }
}
