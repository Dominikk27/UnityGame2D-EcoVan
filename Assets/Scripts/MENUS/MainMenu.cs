using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    
    public int StartMoney = 500;
    
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("City_Scene");
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
