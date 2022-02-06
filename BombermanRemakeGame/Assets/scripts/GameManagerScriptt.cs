using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScriptt : MonoBehaviour
{
    private int player1_lives;
    private int player2_lives;

    private void Start()
    {
        player1_lives = 1;
        player2_lives = 1;
    }

    public int get_player1_lives()
    {
        return player1_lives;
    }

    public void set_player1_lives(int lives)
    {
        player1_lives = lives;
    }

    void Update()
    {
        //Debug.Log(player1_lives);

        if (player1_lives < 1)
        {
            Debug.Log("LOLLLL");
            Destroy(GameObject.FindWithTag("Player1"));
        }

        if (player2_lives < 1)
        {
            Destroy(GameObject.FindWithTag("Player2"));
        }
    }
}
