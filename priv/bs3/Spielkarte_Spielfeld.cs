using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielkarte_Spielfeld : Spielkarte
{
    #region Eigene Kartenwerte (veränderbar)

    private int intGenuss;                  //Veränderbarer Genusswert für gespielte Karte
    private int farbWert;                   //Veränderbarer Farbwert für gespielte Karte
    private string stringName;              //Veränderbarer Name für gespielte Karte
    private string stringEffekt;            //Veränderbarer Effekttext für gespielte Karte

    #endregion

    #region Funktionen Karte zeichnen (optisch)

    public override void Awake()                                                    //Ersetzt ursprüngliches Awake aus "Spielkarte"
    {
        listHolder = FindObjectOfType<ListHolder>();                                //Verknüpft die Karte mit dem immer vorhandenen ListHolder
        intGenuss = listHolder.alleKarten[GetKarteIndex()].genussWert;              //Speichert veränderbaren Genusswert mit Originalwert
        stringName = listHolder.alleKarten[GetKarteIndex()].kartenName;             //Speichert veränderbaren Name mit Originaltext
        stringEffekt = listHolder.alleKarten[GetKarteIndex()].kartenEffekttext;     //Speichert veränderbaren Effekttext mit Originaltext
        farbWert = listHolder.alleKarten[GetKarteIndex()].farbWert;                 //Speichert veränderbaren Farbwert mit Originalwert
        ZeichneKarte();                                                             //Zeichnet die Optikkomponenten der Karte in die Szene
    }

    #endregion

    #region Getter/Setter

    public void SetGenuss(int wert) { intGenuss = wert; }                   //Setzt veränderbaren Genusswert der gespielten Karte neu
    public int GetGenuss() { return intGenuss; }                            //Gibt aktuellen Genusswert der gespielten Karte aus
    public void SetName(string name) { stringName = name; }                 //Setzt veränderbaren Namen der gespielten Karte neu
    public string GetName() { return stringName; }                          //Gibt aktuellen Namen der gespielten Karte aus
    public void SetEffekttext(string text) { stringEffekt = text; }         //Setzt veränderbaren Effekttext der gespielten Karte neu
    public string GetEffekttext() { return stringEffekt; }                  //Gibt aktuellen Effekttext der gespielten Karte aus
    public void SetFarbe(int wert)                                          //Setzt veränderbaren Farbwert der gespielten Karte neu
    {
        farbWert = wert;                                                    //Farbwert setzen
        bildKarte.texture = listHolder.alleFarben[farbWert];                //Kartenfarbe mit passendem Farbrahmen verknüpfen
    }
    public int GetFarbe() { return farbWert; }                              //Gibt den aktuellen Farbwert der gespielten Karte aus

    #endregion
}
