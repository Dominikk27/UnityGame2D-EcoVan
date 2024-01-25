using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetupStats : MonoBehaviour
{
    public int StartMoney = 500;

    private void Awake(){
        DataToStore.currentMoney = StartMoney;   //Save to Static
    }
}
