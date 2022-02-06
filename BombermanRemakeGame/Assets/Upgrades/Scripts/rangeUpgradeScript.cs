using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeUpgradeScript : MonoBehaviour
{
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
                bombScript.rangeEnlargeAllowed = true;
                //Debug.Log("0");
                if(bombScript.rangeEnlargeEnded)
                {//Invoke("DeactivateUpgrade", upgradeCooldown); don't need since we don't have a cooldown
                    Debug.Log("6. rangeEnlargeAllowed " + bombScript.rangeEnlargeAllowed);
                    DeactivateUpgrade();
                    activeOnce = true;     
                }
            }
            else
            {
                if(activeOnce)
                {
                    //resetting allowence, rangeEnlargeAllowed got reseted through Knight Controller. need to reset its end bool for further pickups.
                    bombScript.rangeEnlargeEnded = false;
                    //bombScript.enlargedThrowCounter = 0; //resetting
                    initiatedUpgrade = false; //also for further pickups
                    Debug.Log("Upgrade deactivated.");
                    bombScript.rangeEnlargeAllowed = false;
                    Debug.Log("7. rangeEnlargeAllowed " + bombScript.rangeEnlargeAllowed);
                    Destroy(gameObject);
                }         
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if((other.tag == "Player1" || other.tag == "Player2") && !initiatedUpgrade)
        {
            bombScript = other.gameObject.GetComponent<KnightController>();
            anim.SetBool("pickRange", true);
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
