using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduktInfo : MonoBehaviour {
    public string Nazov { get; set; }
    public string Material { get; set; }
    public int Cena { get; set; }

    public ProduktInfo(string nazov, string material, int cena) {
        Nazov = nazov;
        Material = material;
        Cena = cena;
    }

    public override string ToString() {
        return $"{Nazov} ({Material}) - {Cena:C}";
    }
}