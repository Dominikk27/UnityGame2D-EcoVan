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

    private void Awake()
    {
        get_CurrentMoney = DataToStore.currentMoney;
    }

    void Start()
    {
        get_CurrentMoney = DataToStore.currentMoney;
        currentMoney = get_CurrentMoney.ToString();
        Image moneyBarImage = GetComponentInChildren<Image>();
        if (moneyBarImage != null)
        {
            TextMeshProUGUI moneyVal = moneyBarImage.GetComponentInChildren<TextMeshProUGUI>();
            if (moneyVal != null)
            {
                moneyVal.text = currentMoney;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}



/* Backup
 public Canvas inGameCanv;
    private string MoneyBar = "MoneyBar";

    private int get_CurrentMoney;

    private string currentMoney;


    private void Awake(){
        get_CurrentMoney = DataToStore.currentMoney;
    }

    void Start()
    {
        currentMoney = get_CurrentMoney.ToString();
        Image MoneyBar = inGameCanv.GetComponentInChildren<Image>();
        if (MoneyBar != null){
            TextMeshProUGUI MoneyVal = MoneyBar.GetComponentInChildren<TextMeshProUGUI>();
        if(MoneyVal != null){
            MoneyVal.text = currentMoney;
        }
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

*/