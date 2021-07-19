using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        die,
        died
    }
public class Player : MonoBehaviour
{
    public string nic = "Игрок ";
    public int votes = 0;
    public static Player[] PlayersArray;
    public role role = role.civilian;
    public status status = status.alive;

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
        System.Random rnd = new System.Random();
        PlayersArray[rnd.Next(Menu.NumberOfPlayers)].role = role.mafia;
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
