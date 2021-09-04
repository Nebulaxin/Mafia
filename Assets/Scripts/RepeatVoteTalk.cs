using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RepeatVoteTalk : MonoBehaviour
{
    public TMP_Text NameOfPlayerTMP;
    public TMP_Text TimerTMP;
    public float SeconsLeft;

    private bool takingAway;

    private int NumOfPlayer = 0;

    public void Start()
    {
        SeconsLeft = Menu.TalkTime;
        takingAway = false;
        NameOfPlayerTMP.text = Player.PlayersArray[DayLoopVoteRepeat.indexesVotedNew[NumOfPlayer]].nic + ", speak on";
    }
    void Update()
    {
        if (!takingAway && SeconsLeft > 0)
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
        ++NumOfPlayer;
        if (NumOfPlayer == DayLoopVoteRepeat.numOfVoted)
        {
            SceneManager.LoadScene("DayLoopVoteRepeat");
        }
        else
        {
            NameOfPlayerTMP.text = Player.PlayersArray[DayLoopVoteRepeat.indexesVotedNew[NumOfPlayer]].nic + ", speak on";
            TimerTMP.text = SeconsLeft.ToString();
        }
        SeconsLeft = Menu.TalkTime;
    }
}
