using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static int sceneCounter = 1;
    public bool disableControls = false;
    float loadTime = 3.5f;
    
    private void Start() 
    {
        sceneCounter = SceneManager.GetActiveScene().buildIndex;
    }

    public void ManageFlow()
    {
        Debug.Log("In manage flow");
        Invoke("ManageScene", loadTime);
        disableControls = true;
    }
   public void ManageScene()
   {
       if(sceneCounter < 3)
       {
           Debug.Log("Loading Scene");
           disableControls = false;
           string i = (sceneCounter + 1).ToString();
           SceneManager.LoadScene("Level" + i);
           sceneCounter++;
       }
       else
           SceneManager.LoadScene("EndScene");
       
   }

}
