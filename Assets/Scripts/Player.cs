using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public enum role
    {
        civilian,
        mafia,
        doctor,
        sheriff
    }
    public enum status
    {
        alive,
        healthed,
        die,
        died
    }
public enum health
{
    no,
    heal,
    healed
}
public class Player : MonoBehaviour
{
    public string nic = "Игрок ";
    public int votes = 0;
    public static Player[] PlayersArray;
    public role role = role.civilian;
    public status status = status.alive;
    public health health = health.no;
    private static int mafiaIndex = -1;
    private static int doctorIndex = -1;
    private static int sheriffIndex = -1;

    public static void Create()
    {
        PlayersArray = new Player[Menu.NumberOfPlayers];
        int number = 1;
        for (int column = 0; column < Menu.NumberOfPlayers; column++)
        {
            PlayersArray[column] = new Player();
            PlayersArray[column].nic += number;
            ++number;
        }
        Debug.Log("Menu.doctor.GetComponent<Toggle>().isOn " + Menu.doctor.GetComponent<Toggle>().isOn);
        Debug.Log("Menu.sheriff.GetComponent<Toggle>().isOn " + Menu.sheriff.GetComponent<Toggle>().isOn);
        DistributeMafia();
        if (Menu.doctor.GetComponent<Toggle>().isOn)
        {
            DistributeDoctor();
        }
        if (Menu.sheriff.GetComponent<Toggle>().isOn)
        {
            DistributeSheriff();
        }
    }
    private static void DistributeMafia()
    {
        System.Random rnd = new System.Random();
        mafiaIndex = rnd.Next(Menu.NumberOfPlayers);
        PlayersArray[mafiaIndex].role = role.mafia;
    }
    private static void DistributeDoctor()
    {
        System.Random rnd = new System.Random();
        doctorIndex = rnd.Next(Menu.NumberOfPlayers);
        if (doctorIndex != mafiaIndex)
        {
            PlayersArray[doctorIndex].role = role.doctor;
        }
        else
        {
            DistributeDoctor();
        }
    }
    private static void DistributeSheriff()
    {
        System.Random rnd = new System.Random();
        sheriffIndex = rnd.Next(Menu.NumberOfPlayers);
        if (sheriffIndex != mafiaIndex && sheriffIndex != doctorIndex)
        {
            PlayersArray[sheriffIndex].role = role.sheriff;
        }
        else
        {
            DistributeSheriff();
        }
    }

    public static void ClearVotes()
    {
        for (int column = 0; column < Menu.NumberOfPlayers; column++)
        {
            PlayersArray[column].votes = 0;
        }
        ArrayToConsole.Output("ClearVotes");
    }
}
