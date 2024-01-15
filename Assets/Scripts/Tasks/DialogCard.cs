using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogCard : MonoBehaviour
{
    /*===============[ Variables ]===============*/
    NPC_Controller npcController;
    public List<Sprite> avatar;
    public List<Sprite> material;
    public List<Sprite> product;
    
    TaskManager _taskManager;



    public Image avatarFrame;
    public Image materialFrame;
    public Image productFrame;
    
    private bool _taskCardshown = false;
    

    /*===============[ Test Only Stuff ]===============*/
    public Sprite avatarGirl;
    public Sprite avatarBoy;

    public Sprite glasses;
    public Sprite shoes;
    public Sprite tshirt;

    public Sprite hay;
    public Sprite plastic;
    public Sprite cotton;
    /*===============[ ================ ]===============*/


    void Start()
    {
        _taskManager = GetComponentInParent<TaskManager>();
    }

    void Updade ()
    {
        
    }

    /*===============[ Call Accept ]===============*/
    public void OnAcceptButtonClick()
    {
        // Code to handle the "Accept" button click
        Debug.Log("Accept button clicked");
        _taskManager.AcceptOffer();
        
    }



    /*===============[ Call Decline ]===============*/
    public bool OnDeclineButtonClick()
    {
        // Code to handle the "Decline" button click
        Debug.Log("Decline button clicked");
        _taskManager.DeclineOffer();
        return true;
    }




    /*===============[ SETUP TASK-CARD ]===============*/
    public void initTask(string npcName, string productName, string productMaterial)
    {   
        string curentName = npcName;
        string currentProduct = productName;
        string currentMaterial = productMaterial;




        /*===============[ Card Avatar ]===============*/
        //Debug.Log(curentName);
        if (curentName.Contains("Boy"))
        {
            // currentSprite = _avatar.Find(sprite => sprite.name == "BoyAvatar");
            // _avatarFrame.sprite = currentSprite;
            avatarFrame.sprite = avatarBoy;
            //Debug.Log("Boy avatar displayed");
        }
        else if(curentName.Contains("Girl"))
        {
            // currentSprite = _avatar.Find(sprite => sprite.name == "GirlAvatar");
            // _avatarFrame.sprite = currentSprite;
            avatarFrame.sprite = avatarGirl;
            //Debug.Log("Girl avatar displayed");
        }

        /*===============[ Card Product ]===============*/
        if (currentProduct.Contains("Glasses")){
            productFrame.sprite = glasses;
        }
        else if (currentProduct.Contains("Shoes")){
            productFrame.sprite = shoes;
        }
        else if (currentProduct.Contains("Tshirt")){
            productFrame.sprite = tshirt;
        }


        /*===============[ Card Material ]===============*/
        if (currentMaterial.Contains("Hay")){
            materialFrame.sprite = hay;
        }
        else if (currentMaterial.Contains("Plastic")){
            materialFrame.sprite = plastic;
        }
        else if (currentMaterial.Contains("Cotton")){
            materialFrame.sprite = cotton;
        }

        // Set the avatar image
    }
    
}
