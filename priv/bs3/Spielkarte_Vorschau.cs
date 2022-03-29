using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using DFTGames.Localization;

public class Spielkarte_Vorschau : Spielkarte
{
    #region Referenzen
  
    [SerializeField]
    public List<Texture> alleFarben;                   //Enthält eigene Liste der Farbrahmen, da anderer Rahmen benötigt
    public TextMeshProUGUI textEffekt;                 //Textfeld für den anzeigbaren Effekttext einer Karte

    #endregion

    #region Funktionen Karte zeichnen (optisch)

    public override void OnPointerEnter(PointerEventData eventData) {}      //Ersetzt ursprüngliche Tooltip-Funktion aus "Spielkarte"
    public override void OnPointerExit(PointerEventData eventData) { }      //Ersetzt ursprüngliche Tooltip-Funktion aus "Spielkarte"

    public override void Awake()                                            //Ersetzt ursprüngliches Awake aus "Spielkarte"
    {
        listHolder = FindObjectOfType<ListHolder>();                        //Verknüpft die Karte mit dem immer vorhandenen ListHolder
    }
    public override void ZeichneKarte()             //Schreibt die Originalkarte eines "karteIndex"
    {
        textGenuss.text = listHolder.alleKarten[GetKarteIndex()].genussWert.ToString();                                                 //Schreibt Originalgenusswert auf Vorschau
        textName.GetComponent<LocalizeTM>().localizationKey = listHolder.alleKarten[GetKarteIndex()].kartenName.ToString();             //Schreibt LocalizationKey für Name
        textEffekt.GetComponent<LocalizeTM>().localizationKey = listHolder.alleKarten[GetKarteIndex()].kartenEffekttext.ToString();     //Schreibt LocalizationKey für Effekttext
        bildFarbe.texture = alleFarben[listHolder.alleKarten[GetKarteIndex()].farbWert];                                                //Zeichnet Originalfarbrahmen auf Vorschau
        ZeichneDopplungen();                                                                                                            //Schreibt/Zeichnet die restlichen Komponenten
    }

    public void ZeichneKarte(Spielkarte_Spielfeld karte)                //Schreibt eine potentiell veränderte Karte
    {
        textGenuss.text = karte.GetGenuss().ToString();                                 //Schreibt aktuellen Genusswert auf Vorschau
        textName.GetComponent<LocalizeTM>().localizationKey = karte.GetName();          //Schreibt LocalizationKey für Name
        textEffekt.GetComponent<LocalizeTM>().localizationKey = karte.GetEffekttext();  //Schreibt LocalizationKey für Effekttext
        bildFarbe.texture = alleFarben[karte.GetFarbe()];                               //Zeichnet aktuellen Farbrahmen auf Vorschau
        ZeichneDopplungen();                                                            //Schreibt/Zeichnet die restlichen Komponenten
    }

    private void ZeichneDopplungen()                                                    //Schreibt/Zeichnet statische Komponenten einer Karte
    {
        textErde.text = listHolder.alleKarten[GetKarteIndex()].erdeWert.ToString();     //Schreibt Originalfeldwert auf Vorschau
        textGold.text = listHolder.alleKarten[GetKarteIndex()].goldWert.ToString();     //Schreibt Originalgoldwert auf Vorschau
        bildKarte.texture = listHolder.alleKarten[GetKarteIndex()].kartenBild;          //Zeichnet Originalbild auf Vorschau
        textGenuss.color = Color.white;                                                 //Schriftfeld Genuss auf weiße Farbe setzen
        textErde.color = Color.white;                                                   //Schriftfeld Erde auf weiße Farbe setzen
        textGold.color = Color.white;                                                   //Schriftfeld Gold auf weiße Farbe setzen
        textName.color = Color.white;                                                   //Schriftfeld Name auf weiße Farbe setzen
        textEffekt.color = Color.white;                                                 //Schriftfeld Effekttext auf weiße Farbe setzen
        textEffekt.GetComponent<LocalizeTM>().UpdateLocale();                           //Updatet die aktuelle Optik für das Spiel in Szene
    }

    #endregion
}