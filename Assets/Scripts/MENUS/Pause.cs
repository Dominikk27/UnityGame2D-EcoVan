using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public GameObject warningWorkbench;
    public GameObject warningMaterial;
    public GameObject speechBubble;
    private bool wariningIsActive = false;
    private bool materialWariningIsActive = false;
    public GameObject pausePanel;
    private bool menuIsActive = false;

    // Start is called before the first frame update
    void Start()
    {   
        pausePanel.SetActive(false);
        speechBubble.SetActive(false);
        warningMaterial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WarninngAck(){
        //Debug.Log("Clicked PauseButton " + wariningIsActive);
        if(!wariningIsActive){
            speechBubble.SetActive(true);
            wariningIsActive = true;
        }
        else{
            speechBubble.SetActive(false);
            wariningIsActive = false;
        }

    }


    public void WarninngMaterial(){
        //Debug.Log("Clicked PauseButton " + wariningIsActive);
        if(!materialWariningIsActive){
            warningMaterial.SetActive(true);
            materialWariningIsActive = true;
        }
        else{
            warningMaterial.SetActive(false);
            materialWariningIsActive = false;
        }

    }

    public void pauseMenu() {
        //Debug.Log("Clicked PauseButton " + menuIsActive);
        if(!menuIsActive){
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            menuIsActive = true;
        }
        else{
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            menuIsActive = false;
        }
    }

    public void muteButton()
    {
        AudiotManager.instance.MuteSwitch();
    }

    public void mainMenu(){
        //Debug.Log("Clicked PauseButton " + menuIsActive);
        SceneManager.LoadScene("MainMenu");

    }

    public bool isMuted()
    {
        return AudiotManager.instance.isMuted();
    }
}
