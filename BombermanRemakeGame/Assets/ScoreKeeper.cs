using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public static int P2Score = 0;
    public static int P1Score = 0; 
    
     Text P1_Score;

    Text P2_Score;

    bool toggle = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("P1_Score" + P1Score);
        P1_Score = GameObject.FindGameObjectWithTag("P1Score").GetComponent<Text>();
        P1_Score.text = P1Score.ToString();
        P2_Score = GameObject.FindGameObjectWithTag("P2Score").GetComponent<Text>();
        P2_Score.text = P2Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(toggle)
        {
            if(Explosion.P1Scored || Explosion.P2Scored)
            {
                toggle = false;

                if(Explosion.P1Scored && Explosion.P2Scored)
                {
                    /*int i = int.Parse(P1_Score.text);
                    int a = int.Parse(P2_Score.text);
                    i++;
                    a++;
                    P1_Score.text = i.ToString();
                    P2_Score.text = a.ToString();*/
                    P1Score++;
                    P1_Score.text = P1Score.ToString();
                    P2Score++;
                    P2_Score.text = P1Score.ToString();

                    Explosion.P1Scored = false;
                    Explosion.P2Scored = false;
                }
                else if(Explosion.P1Scored)
                {
                    /*int i = int.Parse(P1_Score.text);
                    i++;
                    P1_Score.text = i.ToString();*/
                    P1Score++;
                    P1_Score.text = P1Score.ToString();
                    Explosion.P1Scored = false;
                }
                else if(Explosion.P2Scored)
                {
                    /*int a = int.Parse(P2_Score.text);
                    a++;
                    P2_Score.text = a.ToString();*/
                    P2Score++;
                    P2_Score.text = P1Score.ToString();
                    Explosion.P2Scored = false;
                }

            }
        }
    }
}
