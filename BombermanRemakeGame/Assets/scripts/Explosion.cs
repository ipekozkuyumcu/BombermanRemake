using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private static int player1_lives= 3;
    private static int player2_lives= 3;
    //public static int P2Score = 0;
    //public static int P1Score = 0;
    bool is_player1_touching = false;
    bool is_player2_touching = false;

    bool is_dead_player1 = false;
    bool is_dead_player2 = false;

    public GameObject game_manager;
    public Text scoreboard;

    SceneController sceneScript;

    //ahmet_change
    GameObject soundManager;

    //ahmet_change_end

    private List<GameObject> breakableObjects = new List<GameObject>();

    //change here

    Text P1Mark;

    Text P2Mark;

    public List<GameObject> upgrades = new List<GameObject>();

    int[] weightPoolUpgrades = 
    {
        40,
        30,
        30
    };

    int DropProb = 30;

    Animator anim; //for breakable chests.
    Animator animDeadPlayer1;
    Animator animDeadPlayer2;

    GameObject Player1;

    GameObject Player2;

    GameObject Player1Death;

    GameObject Player2Death;

    Text P_1;
    Text P_2;

    Color red;
    Color blue;
    Color tie;

    Text P1_Mark;
    Text P2_Mark;

    public static bool P1Scored = false;

    public static bool P2Scored = false;

    // Start is called before the first frame update
    void Start()
    {
        //for red : FF6969
        //for blue : BBC1FF
        //for tie : F8FF84
        
        P1_Mark = GameObject.FindGameObjectWithTag("P1Mark").GetComponent<Text>();
        P2_Mark = GameObject.FindGameObjectWithTag("P2Mark").GetComponent<Text>();

        sceneScript = FindObjectOfType<SceneController>().GetComponent<SceneController>();

        //ahmet_change
        soundManager = GameObject.FindWithTag("explosionSoundManagerTag");
        //ahmet_change_end

        ColorUtility.TryParseHtmlString("#FF6969", out red);
        ColorUtility.TryParseHtmlString("#BBC1FF", out blue);
        ColorUtility.TryParseHtmlString("#F8FF84", out tie);

        P_1 = GameObject.FindGameObjectWithTag("P1_Health_Counter").gameObject.GetComponent<Text>();
        //Debug.Log(P_1.name);
        P_2 = GameObject.FindGameObjectWithTag("P2_Health_Counter").gameObject.GetComponent<Text>();

        scoreboard = GameObject.Find("Scoreboardd").GetComponent<Text>();
        Invoke("DestroyBigBang", 3);
    }

    //getting components here, due to first contact
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        switch (collision.gameObject.tag)
        {
            case "Player1":
                {
                    Player1 = collision.gameObject;
                    Player1Death = collision.gameObject.transform.GetChild(0).gameObject;
                    animDeadPlayer1 = Player1Death.GetComponent<Animator>();
                    EnableMark(true);
                    is_player1_touching = true;
                }
                break;

            case "Player2":
                {
                    Player2 = collision.gameObject;
                    Player2Death = collision.gameObject.transform.GetChild(0).gameObject;
                    animDeadPlayer2 = Player2Death.GetComponent<Animator>();
                    EnableMark(false);
                    is_player2_touching = true;
                }
                break;

            case "Breakable":
                {
                    breakableObjects.Add(collision.gameObject);
                    anim = collision.gameObject.GetComponent<Animator>();
                    anim.SetBool("gonnaExplode", true);
                }
                break;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            DisableMark(true);
            is_player1_touching = false;
        }

        if (collision.gameObject.tag == "Player2")
        {
            DisableMark(false);
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
            if(breakableObjects[i] != null)
            {
                SpawnUpgrades(breakableObjects[i].transform);
                Destroy(breakableObjects[i]);
            }
            //Debug.Log("destroyed" + i);
        }


        if (is_player1_touching) 
        {
            //game_manager.gameObject.GetComponent<GameManagerScriptt>().set_player1_lives(game_manager.gameObject.GetComponent<GameManagerScriptt>().get_player1_lives()-1);
            // Debug.Log(game_manager.gameObject.GetComponent<GameManagerScriptt>().get_player1_lives());

            player1_lives--;
            int i = System.Convert.ToInt32(P_1.text);
            i--;
            P_1.text = i.ToString();

            if(player1_lives<1)
            {
                //Destroy(GameObject.FindWithTag("Player1"));
                //animation of player 1's death
                DisableMark(true);
                Player1.GetComponent<SpriteRenderer>().enabled = false; //disabling parent object visually
                Player1Death.GetComponent<SpriteRenderer>().enabled = true; //enabling child object visually 
                animDeadPlayer1.SetBool("Player1Dead", true);
                sceneScript.ManageFlow();
                Invoke("KillPlayer1", 2f);
                //player1_lives = 3;
                
                //is_dead_player1 = true;
            }
        }
        if (is_player2_touching) 
        {
            //game_manager.gameObject.GetComponent<GameManager>().player2_lives--;
            
            player2_lives--;
            int i = System.Convert.ToInt32(P_2.text);
            i--;
            P_2.text = i.ToString();
            
            if(player2_lives<1)
            {
                //Destroy(GameObject.FindWithTag("Player2"));
                //animation of player 2's death
                DisableMark(false);
                Player2.GetComponent<SpriteRenderer>().enabled = false;
                Player2Death.GetComponent<SpriteRenderer>().enabled = true;
                animDeadPlayer2.SetBool("Player2Dead", true);
                Debug.Log("Player 2 gonna die.");
                sceneScript.ManageFlow();
                Invoke("KillPlayer2", 2f);
                //player2_lives = 3;
                //is_dead_player2 = true;
            }
        }

        /*if (is_dead_player1 && is_dead_player2)
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

        }*/

        //Destroy(transform.parent.gameObject);
        transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;

        //ahmet_change
        soundManager.GetComponent<explode>().explosion_play_sound=true;
        //ahmet_change_end

        Invoke("updateEndStatus", 2f);
        Invoke("DestroyBomb", 2.1f);
    }

    private void SpawnUpgrades(Transform transform)
    {
        int num1 = Random.Range(0, 101);
        //Debug.Log("num1 :" + num1 );
        //Debug.Log("loot drop prob: " + DropProb);
        if(num1 < DropProb)
        {
            //Debug.Log("I'm here!");
            int num2 = Random.Range(0, 101);

            //Debug.Log("num2 :" + num2);

            for(int i = 0; i < weightPoolUpgrades.Length; i++)
            {
                if(num2 < weightPoolUpgrades[i])
                {
                    //Debug.Log("Instantiating!");
                    Instantiate(upgrades[i], transform.position, Quaternion.identity);
                    return;
                }
                else
                {
                    num2 -= weightPoolUpgrades[i];
                }
            }
        }
    }

    private void KillPlayer1()
    {
        //Destroy(GameObject.FindWithTag("Player1"));
        Destroy(Player1);
        is_dead_player1 = true;
    }

    private void KillPlayer2()
    {
        //Destroy(GameObject.FindWithTag("Player2"));
        Debug.Log("Killing Player 2");
        Destroy(Player2);
        is_dead_player2 = true;
    }

    private void DestroyBomb()
    {
        //permanently deletes bomb object
        Destroy(transform.parent.gameObject);
    }

    private void updateEndStatus()
    {
        if (is_dead_player1 && is_dead_player2)
        {
            scoreboard.GetComponent<UnityEngine.UI.Text>().text = "Tie!";
            scoreboard.GetComponent<UnityEngine.UI.Text>().color = tie;
            P1Scored = true;
            P2Scored = true;
            ResetLives();
            //ScoreKeeper.toggle = true;

        } 
        else 
        {

            if (is_dead_player1)
            {
                scoreboard.GetComponent<UnityEngine.UI.Text>().text = "Player Blue Has Won";
                scoreboard.GetComponent<UnityEngine.UI.Text>().color = blue;
                P2Scored = true;
                ResetLives();
                //ScoreKeeper.toggle = true;
            } 
            else if (is_dead_player2)
            {
                scoreboard.GetComponent<UnityEngine.UI.Text>().text = "Player Red Has Won";
                scoreboard.GetComponent<UnityEngine.UI.Text>().color = red;
                P1Scored = true;
                ResetLives();
                //ScoreKeeper.toggle = true;
            }

        }

    }

    void EnableMark(bool isP1)
    {
        if(isP1)
            P1_Mark.gameObject.GetComponent<Text>().enabled = true;
        else
            P2_Mark.gameObject.GetComponent<Text>().enabled = true;

    }

    void DisableMark(bool isP1)
    {
        if(isP1)
            P1_Mark.gameObject.GetComponent<Text>().enabled = false;
        else
            P2_Mark.gameObject.GetComponent<Text>().enabled = false;;
    }

    void ResetLives()
    {
        player1_lives = 3;
        player2_lives = 3;
    }
}
