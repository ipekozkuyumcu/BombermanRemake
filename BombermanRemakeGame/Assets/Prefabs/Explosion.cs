using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    bool is_player1_touching = false;
    bool is_player2_touching = false;

    bool is_dead_player1 = false;
    bool is_dead_player2 = false;

    public GameObject game_manager;
    public Text scoreboard;

    private List<GameObject> breakableObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        scoreboard = GameObject.Find("Scoreboardd").GetComponent<Text>();
        Invoke("DestroyBigBang", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Player1":
                is_player1_touching = true;
                break;

            case "Player2":
                is_player2_touching = true;
                break;

            case "Breakable":
                breakableObjects.Add(collision.gameObject);
                break;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            is_player1_touching = false;
        }

        if (collision.gameObject.tag == "Player2")
        {
            is_player2_touching = false;
        }
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player1" || collision.gameObject.tag == "Player2")
        {
            Collider2D tmpCol = collision.gameObject.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(tmpCol, gameObject.GetComponent<Collider2D>());
        }

        if (collision.gameObject.tag == "Breakable")
        {
            breakableObjects.Add(collision.gameObject);
        }
    }
    */

    private void DestroyBigBang() {
        for (int i = 0; i < breakableObjects.Count; i++)
        {
            Destroy(breakableObjects[i]);
        }


        if (is_player1_touching) {
            //game_manager.gameObject.GetComponent<GameManagerScriptt>().set_player1_lives(game_manager.gameObject.GetComponent<GameManagerScriptt>().get_player1_lives()-1);
            // Debug.Log(game_manager.gameObject.GetComponent<GameManagerScriptt>().get_player1_lives());
            Destroy(GameObject.FindWithTag("Player1"));
            is_dead_player1 = true;
        }
        if (is_player2_touching) {
            //game_manager.gameObject.GetComponent<GameManager>().player2_lives--;
            Destroy(GameObject.FindWithTag("Player2"));
            is_dead_player2 = true;
        }

        if (is_dead_player1 && is_dead_player2)
        {
            scoreboard.GetComponent<UnityEngine.UI.Text>().text = "TIE!";
            scoreboard.GetComponent<UnityEngine.UI.Text>().color = Color.yellow;
        } else {

        if (is_dead_player1)
        {
            scoreboard.GetComponent<UnityEngine.UI.Text>().text = "Player Blue Has Won";
            scoreboard.GetComponent<UnityEngine.UI.Text>().color = Color.blue;
        } else if (is_dead_player2)
        {
            scoreboard.GetComponent<UnityEngine.UI.Text>().text = "Player Red Has Won";
            scoreboard.GetComponent<UnityEngine.UI.Text>().color = Color.red;
        }

        }

        Destroy(transform.parent.gameObject);
    }

}
