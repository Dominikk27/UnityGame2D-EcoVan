using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TaskManager : MonoBehaviour
{
    /*===============[ Variables ]===============*/
    public GameObject TaskCard_Prefab;
    private GameObject currentTaskCard;
    DialogCard dialogCard;
    NPC_Controller npcController;

    private string productName;
    private string productMaterial;
    private int productPrice;


    private List<ProduktInfo> produkty;
    private List<MaterialTyp> materialy;


    public bool tutorial_played;
    public string FactorySceneName;

    /*===============[ Start INIT ]===============*/
    void Start(){
        Time.timeScale = 1f;
        tutorial_played = DataToStore.tutorial_played;
        produkty = new List<ProduktInfo>();
        materialy = new List<MaterialTyp>();
        FactorySceneName = "Factory_scene";

        /*===============[ Product List ]===============*/
        produkty.Add(new ProduktInfo("Glasses", "Hay", 25));
        produkty.Add(new ProduktInfo("Glasses", "Plastic", 40));
        //produkty.Add(new ProduktInfo("Glasses", "PLC", 35.0f));
        produkty.Add(new ProduktInfo("Tshirt", "Cotton", 100));
        //produkty.Add(new ProduktInfo("Oblečenie", "Polyester", 45.0f));

        /*===============[ Material List ]===============*/
        materialy.Add(new MaterialTyp("Hay"));
        materialy.Add(new MaterialTyp("Plastic"));
        //materialy.Add(new MaterialTyp("PLC"));
        materialy.Add(new MaterialTyp("Cotton"));
        //materialy.Add(new MaterialTyp("Polyester"));

    /*
        Debug.Log("Všetky produkty:");
        foreach (var produkt in produkty) {
            Debug.Log(produkt);
        }
    */
    }



    /*===============[ INIT TaskCard Prefab ]===============*/
    public void createTaskCard(string npcName)
    {   
        int randomIndex = UnityEngine.Random.Range(0, produkty.Count);
        ProduktInfo currentTask = produkty[randomIndex];
        productName = currentTask.Nazov;
        productMaterial = currentTask.Material;
        productPrice = currentTask.Cena;

        Debug.Log("Cena: " + productPrice);

        //Debug.Log($"Current product = {productName} Material {productMaterial}");

        npcController = FindObjectOfType<NPC_Controller>();
        if (npcController != null && npcController.inStore == true)
        {
            //Debug.Log("npcCOntroller: " + npcController.name);
            GameObject TaskCard;
            TaskCard = Instantiate(TaskCard_Prefab, transform);
            dialogCard = GetComponentInChildren<DialogCard>();
            // Debug.Log("PREFAB NAME: " + npcName);
            
            if (dialogCard != null)
            {
               // Debug.Log("Name of Prefab: " + npcName);
                dialogCard.initTask(npcName, productName, productMaterial);
                
                // Get the buttons from the instantiated TaskCard
                Button acceptButton = TaskCard.transform.Find("Accept").GetComponent<Button>();
                Button declineButton = TaskCard.transform.Find("Decline").GetComponent<Button>();

                // Add onClick events for the buttons
                acceptButton.onClick.AddListener(() => dialogCard.OnAcceptButtonClick());
                declineButton.onClick.AddListener(() => dialogCard.OnDeclineButtonClick());
            }
            else
            {
                //Debug.LogError("dialogCard is null!");
            }
            // Additional initialization or actions if needed
        }
    }



    /*===============[ Decline Offer ]===============*/
    public void DeclineOffer(){
        if (npcController != null) {
            npcController.LeaveStore();
        }
        Destroy(gameObject);
    }


    /*===============[ Accept Offer ]===============*/
    public void AcceptOffer(){
        //Debug.Log(FactorySceneName);

        if(!tutorial_played){
            string productToStore = productName;
            string materialToStore = productMaterial;
            int productPriceToStore = productPrice;
            DataToStore.productFinished = false;
            DataToStore.pickedMaterial = false;

            DataToStore.payout = productPriceToStore;
            DataToStore.productName = productToStore;   
            DataToStore.productMaterial = materialToStore; 
            SceneManager.LoadScene("Factory_Scene_Tutorial");
            
            Destroy(gameObject);
        }
        else{
            string productToStore = productName;
            string materialToStore = productMaterial;
            int productPriceToStore = productPrice;
            DataToStore.productFinished = false;
            DataToStore.pickedMaterial = false;

            DataToStore.payout = productPriceToStore;
            DataToStore.productName = productToStore;   
            DataToStore.productMaterial = materialToStore; 
            SceneManager.LoadScene(FactorySceneName);
            
            Destroy(gameObject);
        }

    }

}
