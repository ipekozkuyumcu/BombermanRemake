using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    // Start is called before the first frame update
    //BombSpawnLocation_P1
    //BombSpawnLocation_P2

    [SerializeField] GameObject gamePlayerObj;
    [SerializeField] GameObject bombObj;
    [SerializeField] GameObject bombSpawn;
    KeyCode key;
    Transform bombSpawnLoc;
    float coolDown;
    bool canThrow;
    //change here
    public bool extraThrowAllowed = false;

    public bool extraThrowEnded = false;

    public bool rangeEnlargeAllowed = false;

    public bool rangeEnlargeEnded = false;
    public int throwCounter = 0;
    [SerializeField] int allowanceAmount = 2;

    //----------------------------------------------
    [SerializeField] int allowanceAmountEnlarged = 1;

    public int enlargedThrowCounter = 0;

    //public bool hasThrownEnlarge = false;

    [SerializeField] Vector3 rangeScale = new Vector3(0.7f, 0.7f, 1f);

    Vector3 prevScale;
    //change end

    PlayerMovement movementPlayer;
    void Start()
    {
        //disabling the chid object w death animation
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //Debug.Log(gameObject.transform.GetChild(0).gameObject.name);

        if (gamePlayerObj.tag == "Player1") 
            key = KeyCode.Space;
        else key = KeyCode.RightShift;

        movementPlayer = gamePlayerObj.GetComponent<PlayerMovement>();
        prevScale = bombObj.gameObject.GetComponent<Transform>().localScale;
        //Debug.Log(movementPlayer.bomb);
        bombSpawnLoc = bombSpawn.transform;
        canThrow = true;
        coolDown = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //change here
        if (canThrow && !extraThrowAllowed && !rangeEnlargeAllowed) //when extraThrowAllowed false
        {
            if (Input.GetKeyDown(key))
            {
                throwBomb();
                canThrow = false;
                Invoke("handleThrow", coolDown);
            }
        }
        else if(extraThrowAllowed) //when extraThrowAllowed true, disregard canThrow state DUE TU ELSES ONLY ONE WILL BE ACTIVE.
        {
            if (Input.GetKeyDown(key))
            {
                if(throwCounter < allowanceAmount)
                {
                    throwBomb();
                    throwCounter++;
                }
                else
                {   
                    //if all allowances consumed
                    extraThrowAllowed = false;
                    extraThrowEnded = true;
                    throwCounter = 0; //resetting

                    Debug.Log("extraThrowAllowed :" + extraThrowAllowed + ". extraThrowEnded : " + extraThrowEnded );
                }
                
            }
        }
        else if(rangeEnlargeAllowed) //when rangeEnlargeAllowed true, disregard canThrow state
        {   
                //Debug.Log("1. rangeEnlargeAllowed " + rangeEnlargeAllowed);
            //Debug.Log("1. rangeEnlargeAllowed " + rangeEnlargeAllowed);
            if (Input.GetKeyDown(key))
            {
                Debug.Log("2. rangeEnlargeAllowed " + rangeEnlargeAllowed);
                if(enlargedThrowCounter < allowanceAmountEnlarged)
                {
                    //manipulating scale so that collider enlarges
                    Debug.Log("Manipulating scale.");
                    //bombObj.gameObject.GetComponent<Transform>().localScale = rangeScale;
                    //throwBomb();
                    throwEnlargedBomb(); 
                    enlargedThrowCounter++;
                    Debug.Log("Threw in total : " + enlargedThrowCounter);
                    Debug.Log("Total allowance " + allowanceAmountEnlarged);
                    Debug.Log("3. rangeEnlargeAllowed " + rangeEnlargeAllowed);
                }
                else
                {   
                    //if all allowances consumed
                    rangeEnlargeAllowed = false;
                    Debug.Log("rangeEnlargeAllowed setted to : " + rangeEnlargeAllowed);
                    rangeEnlargeEnded = true;
                    enlargedThrowCounter = 0; //resetting (THIS)
                    //rescaling
                    //bombObj.gameObject.GetComponent<Transform>().localScale = prevScale;

                    Debug.Log("Resetted. Upgrade should deactivate.");
                    Debug.Log("4. rangeEnlargeAllowed " + rangeEnlargeAllowed);
                }
                Debug.Log("5. rangeEnlargeAllowed " + rangeEnlargeAllowed);
            }

            //Debug.Log("6. rangeEnlargeAllowed " + rangeEnlargeAllowed);
        }
        /*(else if(extraThrowAllowed && rangeEnlargeAllowed)
        {
            //can throw to large bombs
        }*/
        //end here
        
    }

    void throwBomb()
    {
        Instantiate(bombObj, bombSpawnLoc.position, transform.rotation);
    }

    void throwEnlargedBomb()
    {
        Debug.Log("in throwEnlargedBomb!");
        GameObject enlargedBomb = Instantiate(bombObj, bombSpawnLoc.position, transform.rotation);
        enlargedBomb.gameObject.GetComponent<Transform>().localScale = rangeScale;
    }

    void handleThrow()
    {
        if (!canThrow)
        {
            canThrow = true;
            Debug.Log("handleThrow");
        }
    }
}