using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour
{
    private static int Civilians = 0;
    private static int Mafias = 0;

    public static void AlivePlayes(string SceneEndOfArray, string SceneLivePlayers)
    {
        if (Menu.column == Menu.NumberOfPlayers)
        {
            SceneManager.LoadScene(SceneEndOfArray);
            return;
        }
        switch (Player.PlayersArray[Menu.column].status)
        {
            case "alive":
                SceneManager.LoadScene(SceneLivePlayers);
                break;
            case "die":
                SceneManager.LoadScene(SceneLivePlayers);
                break;
            case "died":
                ++Menu.column;
                AlivePlayes(SceneEndOfArray, SceneLivePlayers);
                break;
            default:
                Debug.Log("Check CheckAlivePlayers()");
                break;
        }
    }
    public static void AliveColumn()
    {
        Debug.Log("Menu.column " + Menu.column);
        if (Menu.column == Menu.NumberOfPlayers)
        {
            return;
        }
        switch (Player.PlayersArray[Menu.column].status)
        {
            case "died":
                ++Menu.column;
                AliveColumn();
                break;
            default:
                return;
        }
    }
    public static void AliveI()
    {
        Debug.Log("number " + DayLoopVote.i);
        if (DayLoopVote.i == Menu.NumberOfPlayers)
        {
            return;
        }
        switch (Player.PlayersArray[DayLoopVote.i].status)
        {
            case "died":
                ++DayLoopVote.i;
                AliveI();
                break;
            default:
                return;
        }
    }
    public static void Role()
    {
        switch (Player.PlayersArray[Menu.column].role)
        {
            case "civilian":
                SceneManager.LoadScene("NightLoopCivilianTask");
                break;
            case "mafia":
                SceneManager.LoadScene("NightLoopMafiaTask");
                break;
            default:
                Debug.Log("NightLoopSwitcher Next()");
                break;
        }
    }
    public static void MafiaTask()
    {
        if (NightLoopMafiaTaskMenu.i < Menu.NumberOfPlayers)
        {
            switch (Player.PlayersArray[NightLoopMafiaTaskMenu.i].role)
            {
                case "mafia":
                    ++NightLoopMafiaTaskMenu.i;
                    MafiaTask();
                    return;
            }
            switch (Player.PlayersArray[NightLoopMafiaTaskMenu.i].status)
            {
                case "die":
                    ++NightLoopMafiaTaskMenu.i;
                    MafiaTask();
                    break;
                case "died":
                    ++NightLoopMafiaTaskMenu.i;
                    MafiaTask();
                    break;
            }
        }
    }
    public static void Win()
    {
        Mafias = 0;
        Civilians = 0;
        for (int i = 0; i < Menu.NumberOfPlayers; i++)
        {
            if (Player.PlayersArray[i].status == "alive")
            {
                switch (Player.PlayersArray[i].role)
                {
                    case "mafia":
                        Mafias++;
                        Debug.Log("Mafias " + Mafias);
                        break;
                    case "civilian":
                        Civilians++;
                        Debug.Log("Civilians " + Civilians);
                        break;
                }
            }
        }
        if (Mafias == 0 && Civilians == 0)
        {
            SceneManager.LoadScene("NoOneWon");
        }
        else if (Mafias == 0)
        {
            SceneManager.LoadScene("CiviliansWon");
        }
        else if (Mafias >= Civilians)
        {
            SceneManager.LoadScene("MafiasWon");
        }
        else
        {
            Debug.Log("NextScene " + DiedPlayers.NextScene);
            SceneManager.LoadScene(DiedPlayers.NextScene);
        }
    }
}