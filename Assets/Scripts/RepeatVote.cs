using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RepeatVote : MonoBehaviour
{
    public TMP_Text Names;

    private void Start()
    {
        Names.text = "";
        for (int i = 0; i < DayLoopVoteRepeat.indexesVotedNew.Length; i++)
        {
            if (DayLoopVoteRepeat.indexesVotedNew[i] != -1)
            {
                Names.text += Player.PlayersArray[DayLoopVoteRepeat.indexesVotedNew[i]].nic + " ";
            }
        }
    }
    public void Next()
    {
        SceneManager.LoadScene("RepeatVoteTalk");
        Player.ClearVotes();
    }
}
