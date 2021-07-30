using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DayLoopTalk : MonoBehaviour
{
    public TMP_Text TimerTMP;
    public TMP_Text NameOfPlayerTMP;
    public float SeconsLeft;

    void Start()
    {
        SeconsLeft = Menu.TalkTime;
        for (int i = 0; i < Menu.NumberOfPlayers; i++)
        {
            if (Player.PlayersArray[i].health == health.heal)
            {
                Player.PlayersArray[i].health = health.healed;
            }
            else if (Player.PlayersArray[i].health == health.healed)
            {
                Player.PlayersArray[i].health = health.no;
            }
        }
        Check.AliveColumn();
        NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", говорите";
        DiedPlayers.NextScene = "Night";
        ArrayToConsole.Output("DayLoopTalk");
        Debug.Log("Menu.TalkTime " + Menu.TalkTime);
    }
    void Update()
    {
        if (SeconsLeft > 0)
        {
            SeconsLeft -= Time.deltaTime;
            TimerTMP.text = Convert.ToString(Convert.ToInt32(SeconsLeft));
        }
        if (SeconsLeft <= 0)
        {
            SeconsLeft = Menu.TalkTime;
            ++Menu.column;
            Check.AliveColumn();

            if (Menu.column == Menu.NumberOfPlayers)
            {
                Menu.column = 0;
                if (Menu.FirstVote)
                {
                    SceneManager.LoadScene("DayLoopVote");
                    Debug.Log("DayLoopVote");
                }
                else
                {
                    SceneManager.LoadScene("NightLoopSwitcher");
                    Debug.Log("NightLoopSwitcher");
                }
            }
            else
            {
                NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", говорите";
                Debug.Log("Update else");
            }
        }
    }
    public void Next()
    {
        SeconsLeft = 0;
    }
}
