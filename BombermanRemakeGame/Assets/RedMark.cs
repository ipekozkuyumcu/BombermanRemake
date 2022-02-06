using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedMark : MonoBehaviour
{
    Text Red_Mark;
    void Start()
    {
        Red_Mark = GameObject.FindGameObjectWithTag("P1Mark").GetComponent<Text>();
        //Red_Mark.gameObject.SetActive(false);
        Red_Mark.gameObject.GetComponent<Text>().enabled = false;
    }

    private void Update() 
    {
        Red_Mark.gameObject.transform.position = gameObject.transform.position;    
    }
}
