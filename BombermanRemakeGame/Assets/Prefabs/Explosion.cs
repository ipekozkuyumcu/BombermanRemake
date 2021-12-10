using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    private List<GameObject> breakableObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBigBang", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
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

    private void DestroyBigBang() {
        for (int i = 0; i < breakableObjects.Count; i++)
        {
            Destroy(breakableObjects[i]);
        }
        Destroy(transform.parent.gameObject);
    }

}
