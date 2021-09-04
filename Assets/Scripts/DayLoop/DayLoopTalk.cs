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
    public bool takingAway;

    void Start()
    {
        SeconsLeft = Menu.TalkTime;
        takingAway = false;
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
        NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", speak on";
        DiedPlayers.NextScene = "Night";
        ArrayToConsole.Output("DayLoopTalk");
        TimerTMP.text = SeconsLeft.ToString();
    }
    void Update()
    {
        if(!takingAway && SeconsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }
    IEnumerator TimerTake()
    {
        takingAway = true;
        SeconsLeft -= 1;
        yield return new WaitForSeconds(1);
        if (SeconsLeft <= 0)
        {
            Next();
        }
        TimerTMP.text = SeconsLeft.ToString();
        takingAway = false;
    }
    public void Next()
    {
        SeconsLeft = Menu.TalkTime;
        ++Menu.column;
        Check.AliveColumn();

        if (Menu.column == Menu.NumberOfPlayers)
        {
            Menu.column = 0;
            if (Menu.FirstVoiting)
            {
                SceneManager.LoadScene("DayLoopVote");
                Debug.Log("DayLoopVote");
            }
            else
            {
                SceneManager.LoadScene("NightLoopSwitcher");
                Debug.Log("NightLoopSwitcher");
                Menu.FirstVoiting = true;
            }
        }
        else
        {
            NameOfPlayerTMP.text = Player.PlayersArray[Menu.column].nic + ", speak on";
            TimerTMP.text = SeconsLeft.ToString();
        }
    }
}
