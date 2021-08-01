using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RepeatVote : MonoBehaviour
{
    public TMP_Text Names;
    public static bool RepeartVote = false;

    private void Start()
    {
        RepeartVote = true;
        Names.text = "";
        for (int i = 0; i < DayLoopVote.numOfVoted; i++)
        {
            Names.text += Player.PlayersArray[DayLoopVote.indexesNew[i]].nic + " ";
        }
    }
    public void Next()
    {
        SceneManager.LoadScene("RepeatVoteTalk");
        Player.ClearVotes();
    }
}
