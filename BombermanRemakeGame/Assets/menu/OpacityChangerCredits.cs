using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OpacityChangerCredits : MonoBehaviour
{
    public bool changeOpacity = false;
    public float image_alpha = 0;
    Color color;
    Text text;
    short order = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
        color = text.color;
        color.a = 0;
        this.gameObject.GetComponent<Text>().color=color;
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
                Invoke("OpacityChange", 4f);
            } else
                   Invoke("OpacityChange", 0.025f);
        } else if(order==1)
        {
            image_alpha -= 0.02f;
            if (image_alpha < 0.02)
            {
                order = 2;
                Invoke("OpacityChange", 2f);
            }
            else
                Invoke("OpacityChange", 0.025f);
        } else
        {
            order = 0;
        }
        color.a = image_alpha;
        text.color = color;
    }
}