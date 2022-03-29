using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class Spielkarte : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Referenzen

    public ListHolder listHolder;           //Zugriff auf alle Karten (kartenInhalt) und Kartenfarben (texture) klein
    private int listeIndex;                 //Sagt, welches GameObject (Child-Nummer) damit in der Szene verkn�pft ist
    private int karteIndex;                 //Gibt die Position in der Liste aller Karten (listHolder) wieder
    public TextMeshProUGUI textName;        //Textfeld f�r den Namen einer Karte

    #endregion

    #region Basic Optikanzeigen

    public Text textGenuss;                 //Textfeld f�r den Genuss einer Karte
    public Text textErde;                   //Textfeld f�r den Erdewert einer Karte
    public Text textGold;                   //Textfeld f�r den Goldwert einer Karte
    public RawImage bildFarbe;              //Bildfeld f�r die Kartenfarbe einer Karte
    public RawImage bildKarte;              //Bildfeld f�r das Kartenbild einer Farbe

    #endregion

    #region Funktionen Karte zeichnen (optisch)

    public virtual void Awake()                             //Wird aufgerufen, sobald eine Karte entsteht und sichtbar wird
    {
        listHolder = FindObjectOfType<ListHolder>();        //Verkn�pft die Karte mit dem immer vorhandenen ListHolder
        ZeichneKarte();                                     //Zeichnet die Optikkomponenten der Karte in die Szene
    }

    public virtual void OnPointerEnter(PointerEventData eventData)      //Wird aufgerufen, wenn der Mauszeiger �ber die Karte hovert
    {
        TooltipSystem.TooltipAnzeigen(textName.text);                   //Zeigt den Tooltip mit dem Namen der Karte am Mauszeiger an
    }

    public virtual void OnPointerExit(PointerEventData eventData)       //Wird aufgerufen, wenn der Mauszeiger nicht mehr �ber die Karte hovert
    {
        TooltipSystem.TooltipVerbergen();                               //Entfernt Tooltip mit dem Namen der Karte vom Mauszeiger wieder
    }

    public virtual void ZeichneKarte()                                                          //Zeichnet die optische Karte in die Szene
    {
        textGenuss.text = listHolder.alleKarten[karteIndex].genussWert.ToString();              //Textfeld Genuss wird Originalwert zugewiesen
        textGenuss.color = Color.white;                                                         //Schriftfeld Genuss auf wei�e Farbe setzen
        textErde.text = listHolder.alleKarten[karteIndex].erdeWert.ToString();                  //Textfeld Erde wird Originalwert zugewiesen
        textErde.color = Color.white;                                                           //Schriftfeld Erde auf wei�e Farbe setzen
        textGold.text = listHolder.alleKarten[karteIndex].goldWert.ToString();                  //Textfeld Gold wird Originalwert zugewiesen
        textGold.color = Color.white;                                                           //Schriftfeld Gold auf wei�e Farbe setzen
        bildKarte.texture = listHolder.alleKarten[karteIndex].kartenBild;                       //Weist das Kartenbild vom Original zu
        bildFarbe.texture = listHolder.alleFarben[listHolder.alleKarten[karteIndex].farbWert];  //Weist den Farbrahmen vom Original zu
    }

    #endregion

    #region Getter/Setter

    public int GetListeIndex() { return listeIndex; }                   //Gibt die Child-Position der Karte in der Szene aus
    public void SetListeIndex(int index) { listeIndex = index; }        //Ver�ndert die Child-Position der Karte in der Szene
    public int GetKarteIndex() { return karteIndex; }                   //Gibt die Listen-Position der Karte im ListHolder aus
    public void SetKarteIndex(int index) { karteIndex = index; }        //Ver�ndert "den Pointer" zur Bezugskarte im ListHolder-Original

    #endregion
}