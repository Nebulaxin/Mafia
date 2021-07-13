using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject Alert;
    public TMP_InputField NumberOfPlayersInputTMP; //it will be private
    public static int NumberOfPlayers = 0;
    public static int column = 0;
    public static int TalkTime = 60;
    public static bool FirstVote = true;
    public static bool LastWord = false;

    // https://www.geeksforgeeks.org/different-ways-to-create-an-object-in-c-sharp/?ref=rp

    public void Ready()
    {
        column = 0;
        Debug.Log("RepeatVote.RepeartVote " + RepeatVote.RepeartVote);
        NumberOfPlayers = Convert.ToInt32(NumberOfPlayersInputTMP.text);
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