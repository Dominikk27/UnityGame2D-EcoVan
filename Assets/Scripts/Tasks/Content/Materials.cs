using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialTyp : MonoBehaviour
{
    public string Typ { get; set; }

    public MaterialTyp(string typ) {
        Typ = typ;
    }
}
