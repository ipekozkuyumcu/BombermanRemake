using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombUpgradeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool secondAllowed = false;
    Animator anim;
    KnightController bombScript;
    [SerializeField] float offset = 2f;
    //[SerializeField] float upgradeCooldown = 1f;
    bool upgradeActive = false;
    bool activeOnce = false;
    bool initiatedUpgrade = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {   
        if(initiatedUpgrade)
        {
            if(upgradeActive)
            {
                
                bombScript.extraThrowAllowed = true;
                
                if(bombScript.extraThrowEnded)
                {//Invoke("DeactivateUpgrade", upgradeCooldown); don't need since we don't have a cooldown
                    DeactivateUpgrade();
                    activeOnce = true;     
                }
            }
            else
            {
                if(activeOnce)
                {
                    //resetting allowence, extraThrowAllowed got reseted through Knight Controller. need to reset its end bool for further pickups.
                    bombScript.extraThrowEnded = false;
                    initiatedUpgrade = false; //also for further pickups
                    bombScript.extraThrowAllowed = false;
                    Debug.Log("Deactivated upgrade, current allowance :" + bombScript.extraThrowAllowed +". End state of extra throws resetted as false :" + bombScript.extraThrowEnded);
                    Destroy(gameObject);
                }         
            }

        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if((other.tag == "Player1" || other.tag == "Player2") && !initiatedUpgrade)
        {
            Debug.Log("Picking up initiated.");
            bombScript = other.gameObject.GetComponent<KnightController>();
            anim.SetBool("pickBombUpgrade", true);
            Invoke("DisableRenderer", offset);
            Invoke("ActivateUpgrade", offset);
            Invoke("InitiationActive", offset);
        }
        
    }

    /*private void OnTriggerStay2D(Collider2D other) 
    {
        
    }*/
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
