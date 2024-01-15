using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkTask : MonoBehaviour
{
    public Button finishButton;
    private GameObject final_product;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        final_product = GameObject.Find("glassesProduct_Object(Clone)");
        if(final_product){
            Debug.Log("Found!");
            finishButton.enabled = true;
        }
        else{
            Debug.Log("NotFOUND");
        }
    }
}
