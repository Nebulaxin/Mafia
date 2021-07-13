using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InputPlayersName : MonoBehaviour
{
    public TMP_InputField NamePlayerInputFieldTMP;
    public TMP_Text PlayersTextTMP;
    public static int NumberOfPlayer = 0;

    public void Start()
    {
        NumberOfPlayer++;
        PlayersTextTMP.text = "Введите Ваше имя, Игрок " + NumberOfPlayer;
        NamePlayerInputFieldTMP.text = Player.PlayersArray[Menu.column].nic;
    }
    public void Clear()
    {
        PlayersTextTMP.text = "";
    }
    public void Next()
    {
        Player.PlayersArray[Menu.column].nic = NamePlayerInputFieldTMP.text;
        ArrayToConsole.Output("Next()");
        SceneManager.LoadScene("ShowRole");
    }
}
