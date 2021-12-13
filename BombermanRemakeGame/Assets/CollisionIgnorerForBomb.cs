using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnorerForBomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Bomb_P1")
        {
            if (collision.gameObject.tag == "Player1")
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            }
        } else if (gameObject.tag == "Bomb_P2")
        {
            if (collision.gameObject.tag == "Player2")
            {
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            }
        }
    }
}
