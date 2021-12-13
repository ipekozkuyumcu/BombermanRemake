using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;

    KeyCode up;
    KeyCode down;
    KeyCode left;
    KeyCode right;
    public KeyCode bomb;
    

    Rigidbody2D rb;
    Animator animator;

    Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if(this.gameObject.tag == "Player1") //WASD + space
        {
            up = KeyCode.W;
            down = KeyCode.S;
            left = KeyCode.A;
            right = KeyCode.D;
            bomb = KeyCode.Space;
        }
        else if(this.gameObject.tag == "Player2") //arrows + tab
        {
            up = KeyCode.UpArrow;
            down = KeyCode.DownArrow;
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
            bomb = KeyCode.RightShift;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //for first player
        if (Input.GetKey(up) || Input.GetKey(down) || Input.GetKey(left) || Input.GetKey(right))
        {
            if (this.gameObject.tag == "Player1") 
            {
                movement.x = Input.GetAxisRaw("Horizontal_P1");
                movement.y = Input.GetAxisRaw("Vertical_P1");
            }

            if(this.gameObject.tag == "Player2")
            {
                movement.x = Input.GetAxisRaw("Horizontal_P2");
                movement.y = Input.GetAxisRaw("Vertical_P2");
            }
            

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            //animator.SetFloat("Speed", movement.sqrMagnitude); //more optimized than using Magnitude.

            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        
    }

}
