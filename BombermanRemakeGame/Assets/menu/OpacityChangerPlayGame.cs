using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class OpacityChangerPlayGame : MonoBehaviour
{
    public bool changeOpacity = false;
    public float image_alpha = 0;
    Color color;
    Color buttonColor;
    TextMeshProUGUI text;
    Button myButton;
    short order = 0;
    public bool is_open = false;

    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        myButton= this.gameObject.GetComponent<Button>();
        buttonColor = myButton.GetComponent<Image>().color;
        buttonColor.a = 0;
        color = text.color;
        color.a = 0;
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().color=color;
        this.gameObject.GetComponent<Button>().GetComponent<Image>().color = buttonColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeOpacity)
        {
            Invoke("OpacityChange", 0.016f);
            changeOpacity = false;
        }
    }

    void OpacityChange()
    {
        if (order == 0)
        {
            image_alpha += 0.02f;
            if (image_alpha > 0.98)
            {
                order = 1;
                is_open = true;
            } else
                   Invoke("OpacityChange", 0.025f);
        } 
        color.a = image_alpha;
        buttonColor.a = image_alpha;
        text.color = color;
        myButton.GetComponent<Image>().color=buttonColor;
    }
}