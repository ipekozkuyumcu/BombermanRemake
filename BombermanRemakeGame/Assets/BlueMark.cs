using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueMark : MonoBehaviour
{
    Text Blue_Mark;
    void Start()
    {
        Blue_Mark = GameObject.FindGameObjectWithTag("P2Mark").GetComponent<Text>();
        //Blue_Mark.gameObject.SetActive(false);
        Blue_Mark.gameObject.GetComponent<Text>().enabled = false;
    }

    private void Update() 
    {
        Blue_Mark.gameObject.transform.position = gameObject.transform.position;    
    }

}
