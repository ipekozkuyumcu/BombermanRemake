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

    PlayerMovement movementPlayer;
    void Start()
    {

        if (gamePlayerObj.tag == "Player1") key = KeyCode.Space;
        else key = KeyCode.RightShift;

        movementPlayer = gamePlayerObj.GetComponent<PlayerMovement>();
        Debug.Log(movementPlayer.bomb);
        bombSpawnLoc = bombSpawn.transform;
        canThrow = true;
        coolDown = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (canThrow)
        {


            if (Input.GetKeyDown(key))
            {
                throwBomb();
                canThrow = false;
                Invoke("handleThrow", coolDown);
            }
        }


    }

    void throwBomb()
    {
        Instantiate(bombObj, bombSpawnLoc.position, transform.rotation);
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