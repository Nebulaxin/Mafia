using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour
{
    private static int Civilians = 0;
    private static int Mafias = 0;
    private static string[] NextScenes = { "NightLoopCivilianTask", "NightLoopMafiaTask", "NightLoopDoctorTask", "NightLoopSheriffTask" };

    public static void AlivePlayes(string SceneEndOfArray, string SceneLivePlayers)
    {
        if (Menu.column == Menu.NumberOfPlayers)
        {
            SceneManager.LoadScene(SceneEndOfArray);
            return;
        }
        switch (Player.PlayersArray[Menu.column].status)
        {
            case status.alive:
                SceneManager.LoadScene(SceneLivePlayers);
                break;
            case status.die:
                SceneManager.LoadScene(SceneLivePlayers);
                break;
            case status.died:
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
            case status.died:
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
            case status.died:
                ++DayLoopVote.i;
                AliveI();
                break;
            default:
                return;
        }
    }
    public static void Role()
    {
        SceneManager.LoadScene(NextScenes[(int)Player.PlayersArray[Menu.column].role]);
    }
    public static void NightMafiaTask()
    {
        if (NightLoopMafiaTask.i < Menu.NumberOfPlayers)
        {
            if (Player.PlayersArray[NightLoopMafiaTask.i].role == role.mafia)
            {
                ++NightLoopMafiaTask.i;
                NightMafiaTask();
                return;
            }
            switch (Player.PlayersArray[NightLoopMafiaTask.i].status)
            {
                case status.died:
                    ++NightLoopMafiaTask.i;
                    NightMafiaTask();
                    break;
            }
        }
    }
    public static void NightSheriffTask()
    {
        if (NightLoopSheriffTask.i < Menu.NumberOfPlayers)
        {
            if (Player.PlayersArray[NightLoopSheriffTask.i].role == role.sheriff)
            {
                ++NightLoopSheriffTask.i;
                NightSheriffTask();
                return;
            }
            switch (Player.PlayersArray[NightLoopSheriffTask.i].status)
            {
                case status.died:
                    ++NightLoopSheriffTask.i;
                    NightSheriffTask();
                    break;
            }
        }
    }
    public static void NightDoctorTask()
    {
        if (NightLoopDoctorTask.i < Menu.NumberOfPlayers)
        {
            switch (Player.PlayersArray[NightLoopDoctorTask.i].status)
            {
                case status.died:
                    ++NightLoopDoctorTask.i;
                    NightDoctorTask();
                    return;
            }
            if (Player.PlayersArray[NightLoopDoctorTask.i].health == health.healed)
            {
                ++NightLoopDoctorTask.i;
                NightDoctorTask();
                return;
            }
        }
    }
    public static void Win()
    {
        Mafias = 0;
        Civilians = 0;
        for (int i = 0; i < Menu.NumberOfPlayers; i++)
        {
            if (Player.PlayersArray[i].status == status.alive)
            {
                if (Player.PlayersArray[i].role == role.mafia)
                {
                    Mafias++;
                    Debug.Log("Mafias " + Mafias);
                }
                else
                {
                    Civilians++;
                    Debug.Log("Civilians " + Civilians);
                }
            }
        }
        if (Mafias == 0 && Civilians == 0)
        {
            Won.Winner = "Nobody have won the game!";
            SceneManager.LoadScene("Won");
        }
        else if (Mafias == 0)
        {
            Won.Winner = "Mafia have won the game!";
            SceneManager.LoadScene("Won");
        }
        else if (Mafias >= Civilians)
        {
            Won.Winner = "Civilians have won the game!";
            SceneManager.LoadScene("Won");
        }
        else
        {
            Debug.Log("NextScene " + DiedPlayers.NextScene);
            SceneManager.LoadScene(DiedPlayers.NextScene);
        }
    }
}