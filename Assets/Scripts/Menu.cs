using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public static GameObject NumberOfPlayersInputTMP;
    public static GameObject TalkTimeInputTMP;
    public static GameObject doctor;
    public static GameObject sheriff;
    public Toggle FirstVoitingToggle;
    public Toggle LastWordToggle;
    public Toggle ShowPlayersRoleToggle;
    public static int NumberOfPlayers;
    public static int NumberOfMafias = 1;
    public static int NumberOfCivilians;
    public static int column = 0;
    public static int TalkTime = 60;
    public static bool FirstVoiting;
    public static bool LastWord;
    public static bool ShowPlayersRole;
    
    public void Start()
    {
        doctor = GameObject.Find("DoctorToggle");
        sheriff = GameObject.Find("SheriffToggle");
        NumberOfPlayersInputTMP = GameObject.Find("NumberOfPlayersInputTMP");
        TalkTimeInputTMP = GameObject.Find("TalkTimeInputTMP");
    }
    public void EndEditNumberOfPlayers()
    {
        if (NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text == "" || Convert.ToInt32(NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text) < 3)
        {
            NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text = "3";
        }
        else if (Convert.ToInt32(NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text) > 100)
        {
            NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text = "100";
        }
        if (Convert.ToInt32(NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text) == 3)
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
    public void EndEditTime()
    {
        if (TalkTimeInputTMP.GetComponent<TMP_InputField>().text == "" || Convert.ToInt32(TalkTimeInputTMP.GetComponent<TMP_InputField>().text) <= 0)
        {
            TalkTimeInputTMP.GetComponent<TMP_InputField>().text = "60";
        }
    }
    public void Ready()
    {
        column = 0;
        NumberOfPlayers = Convert.ToInt32(NumberOfPlayersInputTMP.GetComponent<TMP_InputField>().text);
        TalkTime = Convert.ToInt32(TalkTimeInputTMP.GetComponent<TMP_InputField>().text);
        FirstVoiting = FirstVoitingToggle.isOn;
        LastWord = LastWordToggle.isOn;
        ShowPlayersRole = ShowPlayersRoleToggle.isOn;
        Player.Create();
        DayLoopVoteRepeat.indexesVotedOld = new int[NumberOfPlayers];
        DayLoopVoteRepeat.indexesVotedNew = new int[NumberOfPlayers];
        for (int i = 0; i < NumberOfPlayers; i++)
        {
            DayLoopVoteRepeat.indexesVotedOld[i] = -1;
            DayLoopVoteRepeat.indexesVotedNew[i] = -1;
        }
        ArrayToConsole.Output("Ready()");
        SceneManager.LoadScene("InputPlayersName");
    }
}