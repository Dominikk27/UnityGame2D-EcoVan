using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class CheckStatus : MonoBehaviour
{

    public GameObject FinishButton;
    public GameObject BackButton;

    private bool correctProduct;

    private bool productFinished;

    private int payoutMoney;

    private bool correctMaterial;
    private int getCurrentMoney;
    private int payout;

    private bool tutorial_played;


    // Start is called before the first frame update
    void Start()
    {

        correctMaterial = DataToStore.pickedCorrect_material;

        productFinished = DataToStore.productFinished;
        if(!productFinished){
            if (FinishButton != null){
                FinishButton.SetActive(false);
            }
        }
        else{
          if (FinishButton != null){
                FinishButton.SetActive(true);
            }  
        }
        if(BackButton != null){
            BackButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void finishProduct(bool finalProduct_created){
        if(finalProduct_created){
            Debug.Log("finished");
            FinishButton.SetActive(true);
            DataToStore.productFinished = true;
        }
    }

    public void takeProductToVan(){
        SceneManager.LoadScene("Factory_Scene");
    }

    public void sellToCustomer(){
        tutorial_played = DataToStore.tutorial_played;
        switch(tutorial_played){
            case true:
                if(!correctMaterial){
                    getCurrentMoney = DataToStore.currentMoney;
                    payoutMoney = DataToStore.payout;
                    payoutMoney = payoutMoney / 2;
                    DataToStore.currentMoney = getCurrentMoney + payoutMoney;
                    SceneManager.LoadScene("City_Scene");
                }
                else{
                    getCurrentMoney = DataToStore.currentMoney;
                    payoutMoney = DataToStore.payout;
                    DataToStore.currentMoney = getCurrentMoney + payoutMoney;
                    SceneManager.LoadScene("City_Scene");
                }
            break;
            case false:
                DataToStore.tutorial_played = true;
                if(!correctMaterial){
                    getCurrentMoney = DataToStore.currentMoney;
                    payoutMoney = DataToStore.payout;
                    payoutMoney = payoutMoney / 2;
                    DataToStore.currentMoney = getCurrentMoney + payoutMoney;
                    SceneManager.LoadScene("City_Scene");
                }
                else{
                    getCurrentMoney = DataToStore.currentMoney;
                    payoutMoney = DataToStore.payout;
                    DataToStore.currentMoney = getCurrentMoney + payoutMoney;
                    SceneManager.LoadScene("City_Scene");
                }
            break;
        }
    }
    public void previousScene(){
        SceneManager.LoadScene("Factory_Scene");
    }
}
