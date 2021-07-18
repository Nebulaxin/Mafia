using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum role
    {
        civilian,
        mafia,
        doctor,
        sheiff
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
    public string status = "alive";
    public string role = "civilian";
    public int votes = 0;
    public static Player[] PlayersArray;
    //role role = role.civilian;
    //status status = status.alive;

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
        PlayersArray[rnd.Next(Menu.NumberOfPlayers)].role = "mafia";
        //PlayersArray[rnd.Next(Menu.NumberOfPlayers)].role = role.mafia;
    }
    public static void ClearVotes()
    {
        for (int column = 0; column < Menu.NumberOfPlayers; column++)
        {
            PlayersArray[column].votes = 0;
        }
        ArrayToConsole.Output("ClearVotes");
    }

/*  
 *  array[0, NumOfPlayers] = name
 *  array[1, NumOfPlayers] = role (mafia, civilian)
 *  array[2, NumOfPlayers] = status (alive, die - ещё не ввыведено сообщение о смерти игрока, died - сообщение выведенно)
 *  array[3, NumOfPlayers] = voices in dayloops (numbers)
*/
}
