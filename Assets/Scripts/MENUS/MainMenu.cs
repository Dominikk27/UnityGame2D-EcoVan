using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    public int StartMoney = 500;

    private bool tutorial_played;
    
    public void PlayGame()
    {
        tutorial_played = DataToStore.tutorial_played;

        if (!tutorial_played){
            DataToStore.tutorialScene = 1;
            SceneManager.LoadSceneAsync("City_Scene_Tutorial");
        } else {
            SceneManager.LoadSceneAsync("City_Scene");
        }
        
    }

    public void OpenSettings()
    {
        
    }
    
    void Start()
    {
        DataToStore.currentMoney = StartMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
