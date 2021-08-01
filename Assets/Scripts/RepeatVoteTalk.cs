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
    public float SeconsLeft = Menu.TalkTime;

    private int NumOfPlayer = 0;

    public void Start()
    {
        NameOfPlayerTMP.text = Player.PlayersArray[DayLoopVote.indexesNew[NumOfPlayer]].nic + ", говорите";
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
            ++NumOfPlayer;
            if (NumOfPlayer == DayLoopVote.numOfVoted)
            {
                SceneManager.LoadScene("DayLoopVote");
            }
            else
            {
                NameOfPlayerTMP.text = Player.PlayersArray[DayLoopVote.indexesNew[NumOfPlayer]].nic + ", говорите";
            }
            SeconsLeft = Menu.TalkTime;
        }
    }
    public void Next()
    {
        SeconsLeft = 0;
    }
}
