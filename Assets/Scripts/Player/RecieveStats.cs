using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecieveStats : MonoBehaviour
{
    private string MoneyBar = "MoneyBar"; 

    private int get_CurrentMoney;

    private string currentMoney;

    /*===============[ First Init ]===============*/
    private void Awake()
    {
        get_CurrentMoney = DataToStore.currentMoney;
    }


    /*===============[ Init ]===============*/
    void Start()
    {
        get_CurrentMoney = DataToStore.currentMoney;
        currentMoney = get_CurrentMoney.ToString();
        Image moneyBarImage = GetComponentInChildren<Image>();
        if (moneyBarImage != null)
        {
            TextMeshProUGUI moneyVal = moneyBarImage.GetComponentInChildren<TextMeshProUGUI>(); //Get Element
            if (moneyVal != null)
            {
                moneyVal.text = currentMoney; // Print Money
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}