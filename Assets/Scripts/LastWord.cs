using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LastWord : MonoBehaviour
{
    public TMP_Text TimerTMP;
    public TMP_Text NameOfPlayerTMP;
        
    private float SeconsLeft;
    private bool takingAway;

    void Start()
    {
        SeconsLeft = Menu.TalkTime;
        takingAway = false;
        Check.AliveColumn();
        NameOfPlayerTMP.text = Player.PlayersArray[DiedPlayers.DiedPlayerIndex].nic + ", speak on";
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
            Check.Win();
        }
        TimerTMP.text = SeconsLeft.ToString();
        takingAway = false;
    }
    public void Next()
    {
        SeconsLeft = 0;
    }
}
