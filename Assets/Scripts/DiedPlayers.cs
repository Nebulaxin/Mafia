using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DiedPlayers : MonoBehaviour
{
    public TMP_Text DiedPlayer;
    public static string NextScene;

    private bool DiePlayers = false;
    

    void Start()
    {
        DiedPlayer.text = "";
        FindDiedPlayer();
        DayLoopVote.Debuging();
    }
    public void FindDiedPlayer()
    {
        for (int i = 0; i < Menu.NumberOfPlayers; i++)
        {
            if (Player.PlayersArray[i].status == status.die && Player.PlayersArray[i].health != health.heal)
            {
                DiePlayers = true;
                Player.PlayersArray[i].status = status.died;
                DiedPlayer.text += Player.PlayersArray[i].nic + " ";
            }
        }
        DiedPlayer.text += " покидает(ют) игру";
        if (!DiePlayers)
        {
            DiedPlayer.text = "Никто из игроков не покидает игру";
        }
        DiePlayers = false;
        //ArrayToConsole.Output("DiedPlayers");
    }
    public void Next()
    {
        Menu.column = 0;
        if (Menu.LastWord)
        {
            SceneManager.LoadScene("LastWord");
        }
        else
        {
            Debug.Log("NextScene " + NextScene);
            Check.Win();
        }
    }
}
