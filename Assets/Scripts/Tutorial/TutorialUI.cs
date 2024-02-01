using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class TutorialUI : MonoBehaviour
{   
    private string dialogText;
    public GameObject dialogBox;
    
    private TextMeshProUGUI tutorialText;
    
    public Button Skip;

    public int tutorialScene;

    /*===============[ Setup ]===============*/
    void Start()
    {   
        tutorialText = dialogBox.GetComponentInChildren<TextMeshProUGUI>();
        
        tutorialScene = DataToStore.tutorialScene;
        /*
        if(!tutorialText){
            Debug.Log("nenasiel sa textBox");
        }
        else{
            Debug.Log("Nasiel sa");
        }
        */
        if(tutorialScene == 1){
            firstScene();
        }
        else if(tutorialScene == 2){
            secondScene();
            
        }
    }

    /*===============[ 1st scene Dialog POP-UP ]===============*/
    public void firstScene(){
        Time.timeScale = 0f;
        dialogText = Dialog_Text.Text1;
        tutorialText.text = dialogText;
        dialogBox.SetActive(true);
    }


    /*===============[ 2nd scene Dialog POP-UP ]===============*/
    public void secondScene(){
        Time.timeScale = 0f;
        
        dialogText = Dialog_Text.Text3;
        Debug.Log(dialogText);
        tutorialText.text = dialogText;
        dialogBox.SetActive(true);
       
    }
   

    /*===============[ Close Dialog POP-UP ]===============*/
    public void close_dialogBox(){
        Time.timeScale = 1f;
        dialogBox.SetActive(false);
    }

    /*===============[ Skip Tutorial ]===============*/
    public void SkipTutorial(){
        DataToStore.tutorial_played = true;
        SceneManager.LoadScene("City_Scene");
        Time.timeScale = 1f;
    }



    /*===============[ 1st scene (IN STORE) Dialog POP-UP ]===============*/
    public void NPC_InStoreTutorial(){
        Time.timeScale = 0f;
        dialogText = Dialog_Text.Text2;
        tutorialText.text = dialogText;
        dialogBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
