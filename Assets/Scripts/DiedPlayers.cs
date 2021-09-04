using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DiedPlayers : MonoBehaviour
{
    public TMP_Text DiedPlayer;
    public TMP_Text RolePlayer;
    public static string NextScene;
    public static int DiedPlayerIndex;

    private bool DiePlayers = false;
    private string[] roles = { "civilian", "mafia", "doctor", "sheriff" };

    void Start()
    {
        DiedPlayer.text = "";
        FindDiedPlayer();
    }
    public void FindDiedPlayer()
    {
        for (int i = 0; i < Menu.NumberOfPlayers; i++)
        {
            if (Player.PlayersArray[i].status == status.die && Player.PlayersArray[i].health != health.heal)
            {
                DiedPlayerIndex = i;
                DiePlayers = true;
                Player.PlayersArray[i].status = status.died;
                DiedPlayer.text += Player.PlayersArray[i].nic + " ";
                if (Menu.ShowPlayersRole)
                {
                    RolePlayer.text = "Player was a " + roles[(int)Player.PlayersArray[i].role];
                }
            }
        }
        if (DiePlayers)
        {
            DiedPlayer.text += " has left the game";
        }
        else
        {
            DiedPlayer.text = "Nobody has been left";
        }
    }
    public void Next()
    {
        Menu.column = 0;
        if (Menu.LastWord && DiePlayers)
        {
            SceneManager.LoadScene("LastWord");
        }
        else
        {
            Debug.Log("NextScene " + NextScene);
            Check.Win();
        }
        DiePlayers = false;
    }
}
