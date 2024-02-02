using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SelectTable : MonoBehaviour
{
    //public Canvas InGameGui;
    public GameObject workBenchWarning;
    public GameObject materialWarning;
    private string Product;

    string normalizedProductName;
    /*===============[ Test Only Stuff ]===============*/
    
    
    
    public string ObjectName;
    //public string GlassesTableScene;
    private bool selectedMaterial;



    void Start()
    {
        Product = DataToStore.productName;
        materialWarning.SetActive(false);
        workBenchWarning.SetActive(false);
        normalizedProductName = Product.ToLower();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeScene(string workBenchName){
        switch(workBenchName){
            case "Glasses":
                SceneManager.LoadScene("GlassesTable");
                break;
            case "Clothes":
                SceneManager.LoadScene("ClothesTable");
                break;
            default:
                break;
        }   
    }


    public void tableClicked(){
        Time.timeScale = 1f;
        selectedMaterial = DataToStore.pickedMaterial;
        if (normalizedProductName == "tshirt"){
                Product = "Clothes";
        }
        switch(selectedMaterial){
            case true:
                if (gameObject.name == Product)
                {
                    Debug.Log("Table with " + this.gameObject.name);
                    changeScene(this.gameObject.name);
                }
                else
                {
                    workBenchWarning.SetActive(true);
                    Debug.Log("Not valid operation !!");
                }
            break;
            case false:
                materialWarning.SetActive(true);
                
                if (gameObject.name == Product)
                {
                    //Debug.Log("Table with " + this.gameObject.name);
                    //changeScene(this.gameObject.name);
                }
                else
                {
                    //workBenchWarning.SetActive(true);
                    //Debug.Log("Not valid operation !!");
                }
            break;
        }

        /*
        if(selectedMaterial){
            
                //Debug.Log("Produkt je: " + Product + " Workbench je: "+ gameObject.name);
            if (gameObject.name == Product)
            {
                Debug.Log("Table with " + this.gameObject.name);
                changeScene(this.gameObject.name);
            }
            else
            {
                workBenchWarning.SetActive(true);
                Debug.Log("Not valid operation !!");
            }
        }
        else{
            if (gameObject.name == Product)
            {
                //Debug.Log("Table with " + this.gameObject.name);
                //changeScene(this.gameObject.name);
                materialWarning.SetActive(true);
            }
            else
            {
                materialWarning.SetActive(true);
                //workBenchWarning.SetActive(true);
                //Debug.Log("Not valid operation !!");
            }
        }
        */
    }
}

