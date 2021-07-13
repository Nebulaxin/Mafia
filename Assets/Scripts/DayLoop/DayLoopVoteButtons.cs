using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DayLoopVoteButtons : MonoBehaviour
{
    public void Next()
    {
        DayLoopVote.SeconsLeft = 0;
    }
    public void Vote()
    {
        //GameObject PressedButton = GameObject.Find(name);
        DayLoopVote.IndexVotedPlayer = Convert.ToInt32(name);
        Debug.Log("DayLoopVote.IndexVotedPlayer " + DayLoopVote.IndexVotedPlayer);
        Debug.Log(name);
    }
}