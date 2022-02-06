using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioData;
    public GameObject creditsObject;

    public List<GameObject> levels;

    void Start()
    {
        audioData = GetComponent<AudioSource>();

        int children = transform.childCount;
        for (int i = 0; i < children; i++)
        {
            Button myButton = transform.GetChild(i).gameObject.GetComponent<Button>();
            switch (transform.GetChild(i).gameObject.tag)
            {
                case "Button0":
                    myButton.onClick.AddListener(Button0Duty);
                    break;
                case "Button1":
                    myButton.onClick.AddListener(Button1Duty);
                    break;
                case "Button2":
                    myButton.onClick.AddListener(Button2Duty);
                    break;
                case "Button3":
                    myButton.onClick.AddListener(Button3Duty);
                    break;

                case "LevelSelectionTag":
                        for(short a = 0; a < transform.GetChild(i).childCount; a++)
                        {
                            myButton=transform.GetChild(i).GetChild(a).gameObject.GetComponent<Button>();
                            switch (transform.GetChild(i).GetChild(a).gameObject.tag)
                            {
                                case "Level1SelectionTag":
                                Debug.Log("Level1tag");
                                myButton.onClick.AddListener(LevelButton0Duty);
                                    break;
                                case "Level2SelectionTag":
                                Debug.Log("Level2tag");
                                myButton.onClick.AddListener(LevelButton1Duty);
                                    break;
                                case "Level3SelectionTag":
                                Debug.Log("Level3tag");
                                myButton.onClick.AddListener(LevelButton2Duty);
                                    break;
                            }
                        }
                                            
                    break;
            }

        }
    }

    void Button0Duty()
    {
        for(short i = 0; i < levels.Count; i++)
        {
            GameObject current = levels[i];
            if (current.GetComponent<OpacityChangerPlayGame>().image_alpha < 0.02 && !current.GetComponent<OpacityChangerPlayGame>().is_open) current.GetComponent<OpacityChangerPlayGame>().changeOpacity = true;
        }
        audioData.Play();
    }

    //OPTIONS OLACAKTI �IKARILDI
    void Button1Duty()
    {
        audioData.Play();
    }

    void Button2Duty()
    {
        audioData.Play();
        if(creditsObject.GetComponent<OpacityChangerCredits>().image_alpha< 0.02) creditsObject.GetComponent<OpacityChangerCredits>().changeOpacity = true;
    }

    void Button3Duty()
    {
        audioData.Play();
        Application.Quit();
    }


    void LevelButton0Duty()
    {
        SceneManager.LoadScene("Level1");
    }

    void LevelButton1Duty()
    {
        SceneManager.LoadScene("Level2");
    }

    void LevelButton2Duty()
    {
        SceneManager.LoadScene("Level3");
    }


    // Update is called once per frame
    void Update()
    {
     
    }
}
