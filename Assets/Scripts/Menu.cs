﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject Alert;
    public static GameObject NumberOfPlayersInputTMP;
    public static GameObject TalkTimeInputTMP;
    public static GameObject doctor;
    public static GameObject sheriff;
    public static int NumberOfPlayers;
    public static int NumberOfMafias = 1;
    public static int NumberOfCivilians;
    public static int column = 0;
    public static int TalkTime = 60;
    public static bool FirstVote = true;
    public static bool LastWord = false;
    
    public void Start()
    {
        RepeatVote.RepeartVote = false;
        doctor = GameObject.Find("DoctorToggle");
        sheriff = GameObject.Find("SheriffToggle");
        NumberOfPlayersInputTMP = GameObject.Find("NumberOfPlayersInputTMP");
        TalkTimeInputTMP = GameObject.Find("TalkTimeInputTMP");
    }
    public void EndEdit()
    {
        if (NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text == "" || Convert.ToInt32(NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text) <= 3)
        {
            doctor.GetComponent<Toggle>().isOn = false;
            sheriff.GetComponent<Toggle>().isOn = false;
            doctor.GetComponent<Toggle>().interactable = false;
            sheriff.GetComponent<Toggle>().interactable = false;
        }
        else
        {
            doctor.GetComponent<Toggle>().interactable = true;
            sheriff.GetComponent<Toggle>().interactable = true;
            NumberOfCivilians = Convert.ToInt32(NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text) - NumberOfMafias;
            if (doctor.GetComponent<Toggle>().isOn)
            {
                --NumberOfCivilians;
            }
            if (sheriff.GetComponent<Toggle>().isOn)
            {
                --NumberOfCivilians;
            }
            if (NumberOfCivilians < 2)
            {
                doctor.GetComponent<Toggle>().isOn = false;
                sheriff.GetComponent<Toggle>().isOn = false;
            }
        }

    }
    public void Ready()
    {
        column = 0;
        Debug.Log("RepeatVote.RepeartVote " + RepeatVote.RepeartVote);
        NumberOfPlayers = Convert.ToInt32(NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text);
        TalkTime = Convert.ToInt32(TalkTimeInputTMP.GetComponent<TMP_InputField>().text);
        if (NumberOfPlayers >= 3)
        {
            Player.Create();
            ArrayToConsole.Output("Ready()");
            SceneManager.LoadScene("InputPlayersName");
        }
        else
        {
            Alert.SetActive(true);
        }
    }
    public void CloseAlert()
    {
        Alert.SetActive(false);
    }
}