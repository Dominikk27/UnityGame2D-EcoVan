using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMaterial : MonoBehaviour
{
    
    public Image materialFrame;

    public List<Sprite> glassesMaterial;
    public List<Sprite> tshirtMaterial;
    private Sprite currentSprite;

    public Image MaterialStatus;
    public Sprite correctMaterial;
    public Sprite noncorrectMaterial;

    public Sprite plastic;

    
    private string productName;
    private string productMaterial;
    private int currentIndex;

    private bool materialPicked = false;
    private bool materialSelected;
    private bool correctMaterial_selected;
    private int pickedIndex;

    void Start()
    {   
        materialSelected = DataToStore.pickedMaterial;
        productName = DataToStore.productName;
        productMaterial = DataToStore.productMaterial;
        correctMaterial_selected = DataToStore.pickedCorrect_material;
        

        if(!materialSelected){
            currentIndex = 0;
            MaterialStatus.enabled = false;
            if (productName.Contains("Glasses")){
                if (glassesMaterial.Count > 0 && materialFrame != null)
                {
                    materialFrame.sprite = glassesMaterial[currentIndex];
                    currentSprite = materialFrame.sprite;
                }
            }
            else if (productName.Contains("Shoes")){
                materialFrame.sprite = plastic;
                
            }
            else if (productName.Contains("Tshirt")){
                if (tshirtMaterial.Count > 0 && materialFrame != null)
                {
                    materialFrame.sprite = tshirtMaterial[currentIndex];
                    currentSprite = materialFrame.sprite;
                }   
            }
        }
        else{
            pickedIndex = DataToStore.selectedMaterial_index;
            if(correctMaterial_selected){
                MaterialStatus.sprite = correctMaterial;
                MaterialStatus.enabled = true;
            }
            else{
                MaterialStatus.sprite = noncorrectMaterial;
                MaterialStatus.enabled = true;
            }
            if(productName.Contains("Glasses")){
                materialFrame.sprite = glassesMaterial[pickedIndex];
                currentSprite = materialFrame.sprite;
            }
            else if(productName.Contains("Tshirt")){
                materialFrame.sprite = tshirtMaterial[pickedIndex];
                currentSprite = materialFrame.sprite;
            }
            else if(productName.Contains("Shoes")){
                //materialFrame.sprite = glassesMaterial[currentIndex];
                //currentSprite = materialFrame.sprite;
            }
        }

    }

    public void ShowNextImage()
    {
        if(!materialSelected){
            if (productName.Contains("Glasses")){
                if (glassesMaterial.Count > 0 && materialFrame != null)
                {
                    currentIndex = (currentIndex + 1) % glassesMaterial.Count;
                    materialFrame.sprite = glassesMaterial[currentIndex];
                    currentSprite = materialFrame.sprite;
                }
            }
            else if (productName.Contains("Shoes")){
                materialFrame.sprite = plastic;
                
            }
            else if (productName.Contains("Tshirt")){
                if (tshirtMaterial.Count > 0 && materialFrame != null)
                {
                    currentIndex = (currentIndex + 1) % tshirtMaterial.Count;
                    materialFrame.sprite = tshirtMaterial[currentIndex];
                    currentSprite = materialFrame.sprite;
                }
            
            }
        }
        else{
            Debug.Log("Material is selected");
        }
    }

    public void ShowPreviousImage()
    {
        if (!materialSelected){
            if (productName.Contains("Glasses")){
                if (glassesMaterial.Count > 0 && materialFrame != null){
                    currentIndex = (currentIndex - 1 + glassesMaterial.Count) % glassesMaterial.Count;
                    materialFrame.sprite = glassesMaterial[currentIndex];
                    currentSprite = materialFrame.sprite;
                }
            }
            else if (productName.Contains("Shoes")){
                materialFrame.sprite = plastic;  
            }
            else if (productName.Contains("Tshirt")){
                if (tshirtMaterial.Count > 0 && materialFrame != null){
                    currentIndex = (currentIndex - 1 + tshirtMaterial.Count) % tshirtMaterial.Count;
                    materialFrame.sprite = tshirtMaterial[currentIndex];
                    currentSprite = materialFrame.sprite;
                }
            }
        }
        else{
            //Debug.Log("Material is selected");
        }
    }


    public void pickMaterial(){
        string normalizedProductMaterial = productMaterial.ToLower();
        string normalizedPickedMaterial = currentSprite.name.ToLower();

        //Debug.Log("productMaterial: "+ normalizedProductMaterial + " Sprite: " + normalizedSpriteName);
        if(normalizedProductMaterial != normalizedPickedMaterial){
            //Debug.Log("NonCorrect");
            MaterialStatus.sprite = noncorrectMaterial;
            MaterialStatus.enabled = true;
            DataToStore.pickedMaterial = true;
            DataToStore.pickedMaterial_name = normalizedPickedMaterial;
            DataToStore.pickedCorrect_material = false;
            materialSelected = DataToStore.pickedMaterial;
            DataToStore.selectedMaterial_index = currentIndex;
            materialPicked = true;
        }
        else{
            //Debug.Log("Correct");
            MaterialStatus.sprite = correctMaterial;
            MaterialStatus.enabled = true;


            DataToStore.pickedMaterial = true;
            DataToStore.pickedMaterial_name = normalizedPickedMaterial;
            DataToStore.pickedCorrect_material = true;
            materialSelected = DataToStore.pickedMaterial;
            DataToStore.selectedMaterial_index = currentIndex;


        }
    }




    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Material je: " + currentSprite.name);
    }
}
