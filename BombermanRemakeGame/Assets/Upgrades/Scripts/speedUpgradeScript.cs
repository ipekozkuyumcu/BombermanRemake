using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpgradeScript : MonoBehaviour
{
    Animator anim;
    PlayerMovement moveScript;
    [SerializeField] float offset = 1f;
    [SerializeField] float upgradeCooldown = 2f;
    bool upgradeActive = false;
    bool activeOnce = false;
    bool initiatedUpgrade = false;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(initiatedUpgrade)
        {
            if(upgradeActive)
            {
                moveScript.currentSpeed = moveScript.boostSpeed;
                Debug.Log(moveScript.currentSpeed);
                activeOnce = true;
                Invoke("DeactivateUpgrade", upgradeCooldown);
            }
            else
            {
                if(activeOnce)
                {
                    moveScript.currentSpeed = moveScript.baseSpeed;
                    initiatedUpgrade = false;
                    Debug.Log("Deactivated upgrade, current speed :" + moveScript.currentSpeed);
                    Destroy(gameObject);
                }
            
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        //GameObject.Destroy(this.gameObject, offset);
        if((other.tag == "Player1" || other.tag == "Player2") && !initiatedUpgrade)
        {
            moveScript = other.gameObject.GetComponent<PlayerMovement>();
            anim.SetBool("pickSpeed", true);
            Invoke("DisableRenderer", offset);
            Invoke("ActivateUpgrade", offset);
            Invoke("InitiationActive", offset);
        } 
    }
    
    void DisableRenderer()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    void ActivateUpgrade()
    {
        upgradeActive = true;
    }

    void DeactivateUpgrade()
    {
        upgradeActive = false;
    }

    void InitiationActive()
    {
        initiatedUpgrade = true;
        Debug.Log("Inititation : true");
    }
}
