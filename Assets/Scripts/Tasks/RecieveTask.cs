using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecieveTask : MonoBehaviour
{

    public Image materialFrame;
    public Image productFrame;

    /*===============[ Test Only Stuff ]===============*/

    public Sprite glasses;
    public Sprite shoes;
    public Sprite tshirt;

    public Sprite hay;
    public Sprite plastic;
    public Sprite cotton;



    private string productName;
    private string productMaterial;
    void Start()
    {
        productName = DataToStore.productName;
        productMaterial = DataToStore.productMaterial;

        /*===============[ Card Product ]===============*/
        if (productName.Contains("Glasses")){
            productFrame.sprite = glasses;
        }
        else if (productName.Contains("Shoes")){
            productFrame.sprite = shoes;
        }
        else if (productName.Contains("Tshirt")){
            productFrame.sprite = tshirt;
        }


        /*===============[ Card Material ]===============*/
        if (productMaterial.Contains("Hay")){
            materialFrame.sprite = hay;
        }
        else if (productMaterial.Contains("Plastic")){
            materialFrame.sprite = plastic;
        }
        else if (productMaterial.Contains("Cotton")){
            materialFrame.sprite = cotton;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
