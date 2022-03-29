using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spielkarte_Spielfeld : Spielkarte
{
    #region Eigene Kartenwerte (ver�nderbar)

    private int intGenuss;                  //Ver�nderbarer Genusswert f�r gespielte Karte
    private int farbWert;                   //Ver�nderbarer Farbwert f�r gespielte Karte
    private string stringName;              //Ver�nderbarer Name f�r gespielte Karte
    private string stringEffekt;            //Ver�nderbarer Effekttext f�r gespielte Karte

    #endregion

    #region Funktionen Karte zeichnen (optisch)

    public override void Awake()                                                    //Ersetzt urspr�ngliches Awake aus "Spielkarte"
    {
        listHolder = FindObjectOfType<ListHolder>();                                //Verkn�pft die Karte mit dem immer vorhandenen ListHolder
        intGenuss = listHolder.alleKarten[GetKarteIndex()].genussWert;              //Speichert ver�nderbaren Genusswert mit Originalwert
        stringName = listHolder.alleKarten[GetKarteIndex()].kartenName;             //Speichert ver�nderbaren Name mit Originaltext
        stringEffekt = listHolder.alleKarten[GetKarteIndex()].kartenEffekttext;     //Speichert ver�nderbaren Effekttext mit Originaltext
        farbWert = listHolder.alleKarten[GetKarteIndex()].farbWert;                 //Speichert ver�nderbaren Farbwert mit Originalwert
        ZeichneKarte();                                                             //Zeichnet die Optikkomponenten der Karte in die Szene
    }

    #endregion

    #region Getter/Setter

    public void SetGenuss(int wert) { intGenuss = wert; }                   //Setzt ver�nderbaren Genusswert der gespielten Karte neu
    public int GetGenuss() { return intGenuss; }                            //Gibt aktuellen Genusswert der gespielten Karte aus
    public void SetName(string name) { stringName = name; }                 //Setzt ver�nderbaren Namen der gespielten Karte neu
    public string GetName() { return stringName; }                          //Gibt aktuellen Namen der gespielten Karte aus
    public void SetEffekttext(string text) { stringEffekt = text; }         //Setzt ver�nderbaren Effekttext der gespielten Karte neu
    public string GetEffekttext() { return stringEffekt; }                  //Gibt aktuellen Effekttext der gespielten Karte aus
    public void SetFarbe(int wert)                                          //Setzt ver�nderbaren Farbwert der gespielten Karte neu
    {
        farbWert = wert;                                                    //Farbwert setzen
        bildKarte.texture = listHolder.alleFarben[farbWert];                //Kartenfarbe mit passendem Farbrahmen verkn�pfen
    }
    public int GetFarbe() { return farbWert; }                              //Gibt den aktuellen Farbwert der gespielten Karte aus

    #endregion
}
